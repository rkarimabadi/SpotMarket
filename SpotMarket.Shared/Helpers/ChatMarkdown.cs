using Microsoft.AspNetCore.Components;
using SpotMarket.Shared.Models.Presentation;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace SpotMarket.Shared.Helpers
{
    public enum ChatBlockKind
    {
        /// <summary>متن معمولی پاسخ که به‌صورت مارک‌داون نمایش داده می‌شود</summary>
        Markdown,

        /// <summary>بلاک chart که به نمودار تبدیل می‌شود</summary>
        Chart,

        /// <summary>هر بلاک کد دیگری</summary>
        Code
    }

    /// <summary>
    /// یک تکه از پاسخ دستیار. پاسخ می‌تواند ترکیبی از متن و نمودار باشد و
    /// هر تکه جداگانه رندر می‌شود.
    /// </summary>
    public class ChatContentBlock
    {
        public ChatBlockKind Kind { get; init; }
        public string Text { get; init; } = string.Empty;

        /// <summary>
        /// مشخصات نمودار؛ برای بلاکی که هنوز در جریان پاسخ کامل نشده null است.
        /// </summary>
        public ChartSpec? Chart { get; init; }
    }

    /// <summary>
    /// تبدیل پاسخ دستیار به محتوای قابل نمایش.
    ///
    /// دو نکته که شکل این کد را تعیین کرده است:
    /// ۱) خروجی مدل متن نامعتبر است — بخشی از آن از رکوردهای پایگاه داده می‌آید که اشخاص
    ///    ثالث نوشته‌اند. پس همه‌چیز اول HTML-encode می‌شود و بعد زیرمجموعه‌ای محدود از
    ///    مارک‌داون روی متنِ امن اعمال می‌شود. هیچ HTML خامی از پاسخ عبور نمی‌کند.
    /// ۲) این تابع حین جریان پاسخ و روی متن ناقص هم صدا زده می‌شود، پس نباید به بسته بودن
    ///    بلاک‌ها تکیه کند.
    /// </summary>
    public static class ChatMarkdown
    {
        private static readonly Regex CodeSpanPattern = new(@"`([^`\n]+)`", RegexOptions.Compiled);
        private static readonly Regex BoldPattern = new(@"\*\*([^*]+)\*\*", RegexOptions.Compiled);
        private static readonly Regex ItalicPattern = new(@"\*([^*\n]+)\*", RegexOptions.Compiled);
        private static readonly Regex HeadingPattern = new(@"^(#{1,6})\s+(.*)$", RegexOptions.Compiled);
        private static readonly Regex BulletPattern = new(@"^\s{0,3}[-*•]\s+(.*)$", RegexOptions.Compiled);
        private static readonly Regex OrderedPattern = new(@"^\s{0,3}\d+[.)]\s+(.*)$", RegexOptions.Compiled);
        private static readonly Regex RulePattern = new(@"^\s{0,3}(-{3,}|\*{3,}|_{3,})\s*$", RegexOptions.Compiled);
        private static readonly Regex TableDividerPattern = new(@"^\s*\|?[\s:|-]*-[\s:|-]*\|?\s*$", RegexOptions.Compiled);

        /// <summary>
        /// پیوند مارک‌داون. فقط مسیر نسبی (شروع با /) گرفته می‌شود؛ الگو عمداً هیچ نشانی
        /// مطلقی را نمی‌پذیرد تا <c>javascript:</c> و دامنه‌ی بیرونی اصلاً به مرحله‌ی بعد نرسد.
        /// </summary>
        private static readonly Regex LinkPattern =
            new(@"\[([^\]\n]{1,80})\]\((/[^)\s""]{1,200})\)", RegexOptions.Compiled);

        /// <summary>
        /// مسیرهای مجازِ پیوند در پاسخ دستیار — همان مسیرهایی که در این برنامه صفحه دارند.
        ///
        /// چرا فهرست سفید: نشانی را مدل زبانی در متن پاسخ می‌نویسد و بخشی از داده‌ای که مدل
        /// می‌بیند (اخبار، اطلاعیه‌ها، نام‌ها) را اشخاص ثالث نوشته‌اند. سمت سرور
        /// (<c>AppRoutes</c> در IME.SpotDataApi) نشانی درست را کنار هر موجودیت می‌گذارد و مدل
        /// فقط رونویسی می‌کند، ولی این لایه به آن تکیه نمی‌کند: هر نشانی‌ای که دقیقاً با یکی
        /// از این الگوها جور نباشد، به‌جای پیوند، متن ساده رندر می‌شود.
        /// </summary>
        /// <summary>
        /// خانه‌ای که فقط یک مسیر نسبی است (بدون هیچ متن دیگری) — نشانه‌ی ستون «لینک».
        /// </summary>
        private static readonly Regex BareRoutePattern =
            new(@"^/[A-Za-z0-9\-_/]{1,200}$", RegexOptions.Compiled);

        private static readonly Regex AllowedRoutePattern = new(
            @"^/(players/(brokers|suppliers)/\d{1,9}"
            + @"|offers/\d{1,9}"
            + @"|commodity-tree/(commodities|groups|main-groups|sub-groups)/\d{1,9}"
            + @"|trading-halls/\d{1,9})$",
            RegexOptions.Compiled);

        private static readonly JsonSerializerOptions ChartJsonOptions = new(JsonSerializerDefaults.Web);

        private const string ChartFenceLanguage = "chart";

        /// <summary>حداکثر دسته‌های یک نمودار؛ فراتر از این روی موبایل خوانا نیست.</summary>
        private const int MaxChartCategories = 12;

        /// <summary>
        /// متن پاسخ را به تکه‌های متن و نمودار می‌شکند.
        /// </summary>
        public static IReadOnlyList<ChatContentBlock> Parse(string? text)
        {
            var blocks = new List<ChatContentBlock>();
            if (string.IsNullOrWhiteSpace(text)) return blocks;

            var lines = text.Replace("\r\n", "\n").Split('\n');
            var buffer = new List<string>();

            void FlushMarkdown()
            {
                if (buffer.Count == 0) return;
                var joined = string.Join("\n", buffer).Trim();
                buffer.Clear();
                if (joined.Length > 0)
                {
                    blocks.Add(new ChatContentBlock { Kind = ChatBlockKind.Markdown, Text = joined });
                }
            }

            for (var i = 0; i < lines.Length; i++)
            {
                var trimmed = lines[i].TrimStart();
                if (!IsFence(trimmed))
                {
                    buffer.Add(lines[i]);
                    continue;
                }

                FlushMarkdown();

                var language = trimmed[3..].Trim();
                var content = new List<string>();
                var closed = false;
                i++;
                for (; i < lines.Length; i++)
                {
                    if (IsFence(lines[i].TrimStart()))
                    {
                        closed = true;
                        break;
                    }
                    content.Add(lines[i]);
                }

                var body = string.Join("\n", content);
                if (language.Equals(ChartFenceLanguage, StringComparison.OrdinalIgnoreCase))
                {
                    // بلاک نیمه‌تمام حین جریان: نمودار بدون مشخصات، تا صفحه به‌جای نمایش
                    // JSON خام یک نشانگر انتظار نشان دهد.
                    blocks.Add(new ChatContentBlock
                    {
                        Kind = ChatBlockKind.Chart,
                        Chart = closed ? ParseChart(body) : null
                    });
                }
                else
                {
                    blocks.Add(new ChatContentBlock { Kind = ChatBlockKind.Code, Text = body });
                }
            }

            FlushMarkdown();
            return blocks;
        }

        private static bool IsFence(string trimmedLine) => trimmedLine.StartsWith("```", StringComparison.Ordinal);

        /// <summary>
        /// مشخصات نمودار را از بدنه بلاک می‌خواند و اعتبارسنجی می‌کند.
        /// خروجی نامعتبر مدل نباید به رسم نمودار بی‌معنا منجر شود.
        /// </summary>
        public static ChartSpec? ParseChart(string json)
        {
            ChartSpec? spec;
            try
            {
                spec = JsonSerializer.Deserialize<ChartSpec>(json, ChartJsonOptions);
            }
            catch (JsonException)
            {
                return null;
            }

            if (spec is null || spec.Labels.Count == 0 || spec.Series.Count == 0) return null;

            var type = string.Equals(spec.Type?.Trim(), "line", StringComparison.OrdinalIgnoreCase) ? "line" : "bar";
            var labels = spec.Labels.Take(MaxChartCategories).ToList();

            var series = spec.Series
                .Where(s => s.Values.Count > 0)
                // مدل گاهی تعداد مقادیر را با تعداد برچسب‌ها هماهنگ نمی‌کند؛ اضافه‌ها بریده می‌شوند.
                .Select(s => new ChartSeries { Name = s.Name, Values = s.Values.Take(labels.Count).ToList() })
                .ToList();

            if (series.Count == 0) return null;

            return new ChartSpec
            {
                Type = type,
                Title = spec.Title,
                Unit = spec.Unit,
                Labels = labels,
                Series = series
            };
        }

        /// <summary>
        /// زیرمجموعه پشتیبانی‌شده مارک‌داون را به HTML امن تبدیل می‌کند:
        /// سرتیتر، پررنگ، مورب، کد درون‌خطی، فهرست، نقل‌قول، خط جداکننده و جدول.
        /// </summary>
        public static MarkupString ToHtml(string? markdown)
        {
            if (string.IsNullOrWhiteSpace(markdown)) return new MarkupString(string.Empty);

            var lines = markdown.Replace("\r\n", "\n").Split('\n');
            var html = new StringBuilder();

            for (var i = 0; i < lines.Length;)
            {
                var line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    i++;
                    continue;
                }

                if (RulePattern.IsMatch(line))
                {
                    html.Append("<hr />");
                    i++;
                    continue;
                }

                var heading = HeadingPattern.Match(line);
                if (heading.Success)
                {
                    // سرتیترهای پاسخ نباید با سرتیتر خود صفحه هم‌وزن شوند، پس دو سطح پایین‌تر می‌آیند.
                    var level = Math.Min(heading.Groups[1].Value.Length + 2, 6);
                    html.Append("<h").Append(level).Append('>')
                        .Append(Inline(heading.Groups[2].Value))
                        .Append("</h").Append(level).Append('>');
                    i++;
                    continue;
                }

                if (IsTableStart(lines, i))
                {
                    i = AppendTable(html, lines, i);
                    continue;
                }

                if (BulletPattern.IsMatch(line) || OrderedPattern.IsMatch(line))
                {
                    i = AppendList(html, lines, i);
                    continue;
                }

                if (IsQuote(line))
                {
                    var quote = new List<string>();
                    while (i < lines.Length && IsQuote(lines[i]))
                    {
                        quote.Add(lines[i].TrimStart().TrimStart('>').TrimStart());
                        i++;
                    }
                    html.Append("<blockquote>").Append(Inline(string.Join(" ", quote))).Append("</blockquote>");
                    continue;
                }

                var paragraph = new List<string>();
                while (i < lines.Length && IsParagraphLine(lines, i))
                {
                    paragraph.Add(lines[i].Trim());
                    i++;
                }

                html.Append("<p>").Append(string.Join("<br />", paragraph.Select(Inline))).Append("</p>");
            }

            return new MarkupString(html.ToString());
        }

        private static bool IsQuote(string line) => line.TrimStart().StartsWith(">", StringComparison.Ordinal);

        private static bool IsParagraphLine(string[] lines, int index)
        {
            var line = lines[index];
            return !string.IsNullOrWhiteSpace(line)
                   && !HeadingPattern.IsMatch(line)
                   && !RulePattern.IsMatch(line)
                   && !BulletPattern.IsMatch(line)
                   && !OrderedPattern.IsMatch(line)
                   && !IsQuote(line)
                   && !IsTableStart(lines, index);
        }

        private static bool IsTableStart(string[] lines, int index)
        {
            if (!lines[index].TrimStart().StartsWith("|", StringComparison.Ordinal)) return false;
            if (index + 1 >= lines.Length) return false;

            var divider = lines[index + 1];
            return divider.Contains('-') && TableDividerPattern.IsMatch(divider);
        }

        private static int AppendTable(StringBuilder html, string[] lines, int index)
        {
            var headers = SplitRow(lines[index]);
            index += 2; // خط عنوان و خط جداکننده

            var rows = new List<string[]>();
            while (index < lines.Length && lines[index].TrimStart().StartsWith("|", StringComparison.Ordinal))
            {
                rows.Add(SplitRow(lines[index]));
                index++;
            }

            var skipped = FindRouteOnlyColumns(headers, rows);

            html.Append("<div class=\"chat-table-scroll\"><table class=\"chat-table\"><thead><tr>");
            for (var column = 0; column < headers.Length; column++)
            {
                if (skipped.Contains(column)) continue;
                html.Append("<th>").Append(Inline(headers[column])).Append("</th>");
            }
            html.Append("</tr></thead><tbody>");

            foreach (var row in rows)
            {
                html.Append("<tr>");
                for (var column = 0; column < row.Length; column++)
                {
                    if (skipped.Contains(column)) continue;
                    html.Append("<td>").Append(Inline(row[column])).Append("</td>");
                }
                html.Append("</tr>");
            }

            html.Append("</tbody></table></div>");
            return index;
        }

        /// <summary>
        /// ستون‌هایی را پیدا می‌کند که خانه‌هایشان چیزی جز نشانی خام صفحه نیستند.
        ///
        /// مدل گاهی کنار نام موجودیت یک ستون «لینک» هم می‌سازد و مسیر را در آن به‌صورت
        /// متن ساده می‌گذارد. چون نام موجودیت خودش پیوند شده است، آن ستون هم تکراری است
        /// و هم بدون قالب‌بندی دیده می‌شود؛ پس اینجا حذف می‌شود. معیار، شکل خانه‌هاست نه
        /// عنوان ستون، تا با هر واژه‌ای که مدل برای عنوان انتخاب کند کار کند.
        /// </summary>
        private static HashSet<int> FindRouteOnlyColumns(string[] headers, List<string[]> rows)
        {
            var skipped = new HashSet<int>();
            if (rows.Count == 0) return skipped;

            for (var column = 0; column < headers.Length; column++)
            {
                var sawRoute = false;
                var allRoutes = true;

                foreach (var row in rows)
                {
                    if (column >= row.Length) continue;

                    var cell = row[column];
                    if (cell.Length == 0) continue;

                    if (BareRoutePattern.IsMatch(cell))
                        sawRoute = true;
                    else
                    {
                        allRoutes = false;
                        break;
                    }
                }

                if (sawRoute && allRoutes) skipped.Add(column);
            }

            // اگر همه‌ی ستون‌ها نشانی بودند، جدول را خالی نمی‌کنیم.
            return skipped.Count == headers.Length ? new HashSet<int>() : skipped;
        }

        private static string[] SplitRow(string line)
        {
            return line.Trim().Trim('|').Split('|').Select(cell => cell.Trim()).ToArray();
        }

        private static int AppendList(StringBuilder html, string[] lines, int index)
        {
            var ordered = OrderedPattern.IsMatch(lines[index]) && !BulletPattern.IsMatch(lines[index]);
            var tag = ordered ? "ol" : "ul";
            html.Append('<').Append(tag).Append('>');

            while (index < lines.Length)
            {
                var bullet = BulletPattern.Match(lines[index]);
                var numbered = OrderedPattern.Match(lines[index]);
                if (!bullet.Success && !numbered.Success) break;

                var item = bullet.Success ? bullet.Groups[1].Value : numbered.Groups[1].Value;
                html.Append("<li>").Append(Inline(item)).Append("</li>");
                index++;
            }

            html.Append("</").Append(tag).Append('>');
            return index;
        }

        /// <summary>
        /// قالب‌بندی درون‌خطی. متن اول encode می‌شود تا هیچ برچسب HTML از پاسخ عبور نکند،
        /// و کدهای درون‌خطی جدا نگه داشته می‌شوند تا ستاره‌های داخلشان پررنگ تفسیر نشوند.
        /// </summary>
        private static string Inline(string raw)
        {
            var encoded = WebUtility.HtmlEncode(raw);
            var result = new StringBuilder();
            var last = 0;

            foreach (Match match in CodeSpanPattern.Matches(encoded))
            {
                result.Append(Emphasis(encoded[last..match.Index]));
                result.Append("<code>").Append(match.Groups[1].Value).Append("</code>");
                last = match.Index + match.Length;
            }

            result.Append(Emphasis(encoded[last..]));
            return result.ToString();
        }

        private static string Emphasis(string text)
        {
            // پیوندها قبل از پررنگ/کج اعمال می‌شوند تا برچسبِ داخل پیوند هم بتواند پررنگ باشد.
            // نشانی خروجی هیچ ستاره‌ای ندارد (فهرست سفید فقط حرف و رقم و / را می‌پذیرد)،
            // پس الگوهای بعدی نمی‌توانند تگ <a> را خراب کنند.
            text = LinkPattern.Replace(text, RenderLink);
            text = BoldPattern.Replace(text, "<strong>$1</strong>");
            return ItalicPattern.Replace(text, "<em>$1</em>");
        }

        /// <summary>
        /// یک پیوند مارک‌داون را به تگ لنگر تبدیل می‌کند، مشروط به اینکه مسیرش در فهرست
        /// سفید باشد. مسیر ناشناخته (یا شناسه‌ی بی‌ربط) پیوند نمی‌شود و فقط برچسبش می‌ماند،
        /// چون فرستادن کاربر به صفحه‌ی ۴۰۴ بدتر از نبودِ پیوند است.
        ///
        /// برچسب و مسیر هر دو از متنی می‌آیند که پیش‌تر HTML-encode شده است، پس اینجا
        /// دوباره encode نمی‌شوند؛ فهرست سفید هم شکل مسیر را کاملاً محدود می‌کند.
        /// </summary>
        private static string RenderLink(Match match)
        {
            var label = match.Groups[1].Value;
            var href = match.Groups[2].Value;

            if (!AllowedRoutePattern.IsMatch(href))
                return label;

            return $"<a href=\"{href}\" class=\"chat-link\">{label}</a>";
        }
    }
}
