export let chartInstances = {};

// نشانی کتابخانه‌ی Chart.js. تنها مصرف‌کننده‌اش صفحه‌ی گفتگوست، پس به‌جای اینکه در
// هر بار باز شدن برنامه بارگذاری شود، همین‌جا و فقط هنگام رسم نخستین نمودار خوانده
// می‌شود. نتیجه‌ی وعده نگه داشته می‌شود تا چند نمودار هم‌زمان، یک بار بیشتر آن را
// بارگذاری نکنند.
const chartJsUrl = '_content/SpotMarket.Shared/js/chart.js';
let chartJsPromise = null;

function ensureChartJs() {
    if (typeof Chart !== 'undefined') return Promise.resolve();

    chartJsPromise ??= new Promise((resolve, reject) => {
        const script = document.createElement('script');
        script.src = chartJsUrl;
        script.onload = () => resolve();
        script.onerror = () => {
            // وعده‌ی شکست‌خورده را دور می‌ریزیم تا نمودار بعدی بتواند دوباره تلاش کند.
            chartJsPromise = null;
            reject(new Error('Chart.js failed to load'));
        };
        document.head.appendChild(script);
    });

    return chartJsPromise;
}

// پالت نمودارهای گفتگو؛ هم‌راستا با متغیرهای رنگ برنامه در app.css
const chatChartPalette = ['#5e72e4', '#2dce89', '#fb6340', '#ffb300', '#673ab7', '#26a69a', '#f5365c'];

// رسم نمودار پیشنهادی دستیار. spec همان ساختار بلاک chart در پاسخ مدل است و
// پیش از رسیدن به اینجا سمت کلاینت اعتبارسنجی شده است.
export async function renderChatChart(canvasId, spec) {
    const canvas = document.getElementById(canvasId);
    if (!canvas || !spec) return;

    await ensureChartJs();

    // بارگذاری کتابخانه زمان می‌برد؛ ممکن است کاربر در همین فاصله صفحه را ترک کرده
    // و بوم از سند برداشته شده باشد.
    if (!canvas.isConnected) return;

    const ctx = canvas.getContext('2d');
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
    }

    const isLine = spec.type === 'line';
    const datasets = spec.series.map((series, index) => {
        const color = chatChartPalette[index % chatChartPalette.length];
        return {
            label: series.name || spec.title || '',
            data: series.values,
            backgroundColor: isLine ? 'transparent' : color,
            borderColor: color,
            borderWidth: isLine ? 2 : 0,
            borderRadius: isLine ? 0 : 6,
            tension: 0.3,
            pointRadius: isLine ? 3 : 0,
            fill: false
        };
    });

    const font = { family: 'PeydaWebFaNum' };
    // راهنما فقط وقتی معنا دارد که بیش از یک سری داده روی نمودار باشد.
    const showLegend = datasets.length > 1;
    const unitSuffix = spec.unit ? ' ' + spec.unit : '';

    chartInstances[canvasId] = new Chart(ctx, {
        type: isLine ? 'line' : 'bar',
        data: { labels: spec.labels, datasets: datasets },
        options: {
            responsive: true,
            maintainAspectRatio: false,
            plugins: {
                legend: { display: showLegend, position: 'bottom', labels: { font: font } },
                tooltip: {
                    rtl: true,
                    titleFont: font,
                    bodyFont: font,
                    callbacks: {
                        label: (item) => item.formattedValue + unitSuffix
                    }
                }
            },
            scales: {
                x: { ticks: { font: font }, grid: { display: false } },
                y: { ticks: { font: font }, beginAtZero: true }
            }
        }
    });
}

export function destroyChart(canvasId) {
    if (chartInstances[canvasId]) {
        chartInstances[canvasId].destroy();
        delete chartInstances[canvasId];
    }
}
