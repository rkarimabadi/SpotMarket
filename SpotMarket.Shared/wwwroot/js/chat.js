// کمکی‌های رابط گفتگو. همه توابع در برابر نبودن عنصر مقاوم‌اند، چون هنگام
// جریان پاسخ ممکن است بلیزور همان لحظه در حال جایگزینی گره‌ها باشد.

// ظرف پیمایش، خودِ main-container در چیدمان اصلی است؛ به‌جای پیدا کردن آن،
// نشانگر انتهای گفتگو را به دید می‌آوریم تا با هر تغییر چیدمان درست کار کند.
export function scrollToEnd(element) {
    if (!element) return;
    element.scrollIntoView({ block: 'end' });
}

// ارتفاع کادر نوشتن با متن رشد می‌کند تا کاربر پرسش چندخطی را کامل ببیند،
// اما تا سقفی که صفحه گفتگو را نبلعد.
export function autoGrow(element, maxHeight) {
    if (!element) return;
    element.style.height = 'auto';
    const limit = maxHeight || 140;
    element.style.height = Math.min(element.scrollHeight, limit) + 'px';
}

export function focusElement(element) {
    if (!element) return;
    element.focus();
}
