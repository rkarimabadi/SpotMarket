export function showSwiftToast(toastId) {
    const toastEl = document.getElementById(toastId);
    if (!toastEl) return;

    // Use a short timeout to allow the element to be rendered before adding the class
    // This ensures the CSS transition is triggered correctly.
    setTimeout(() => {
        toastEl.classList.add('show');
    }, 10);
}

export function hideSwiftToast(toastId) {
    const toastEl = document.getElementById(toastId);
    if (!toastEl) return;

    // Remove the 'show' class to trigger the fade-out animation
    toastEl.classList.remove('show');
}