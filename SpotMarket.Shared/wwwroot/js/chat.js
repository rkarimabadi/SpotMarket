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

// Enter پیام را می‌فرستد و Shift+Enter خط جدید می‌سازد.
//
// چرا در جاوااسکریپت: بلیزور preventDefault را هنگام رندر تعیین می‌کند، نه هنگام
// رویداد؛ پس نمی‌تواند «فقط وقتی Shift گرفته نشده» جلوی رفتار پیش‌فرض را بگیرد.
// بدون preventDefault هم پیام می‌رفت و هم یک خط خالی در کادر جا می‌ماند.
//
// فقط روی دستگاه‌های دارای صفحه‌کلید سخت‌افزاری فعال می‌شود: روی صفحه‌ی لمسی
// Shift در دسترس نیست و کاربر هیچ راهی برای نوشتن پرسش چندخطی نمی‌داشت؛ آنجا
// ارسال با همان دکمه‌ی کنار کادر انجام می‌شود.
export function enableEnterToSend(element, dotNetRef) {
    if (!element || !window.matchMedia('(pointer: fine)').matches) return;

    element.addEventListener('keydown', (event) => {
        // isComposing یعنی صفحه‌کلید در حال ساختن یک نویسه است (مثلاً ورودی‌های
        // چندمرحله‌ای)؛ Enter آنجا نویسه را تأیید می‌کند و نباید پیام بفرستد.
        if (event.key !== 'Enter' || event.isComposing) return;
        if (event.shiftKey || event.altKey || event.ctrlKey || event.metaKey) return;

        event.preventDefault();
        dotNetRef.invokeMethodAsync('SubmitFromKeyboard');
    });
}
