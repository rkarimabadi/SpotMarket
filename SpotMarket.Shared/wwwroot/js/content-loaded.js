function setupResizeObserver(element, dotNetHelper) {
    const observer = new ResizeObserver(() => {
        dotNetHelper.invokeMethodAsync('OnTopNavResized');
    });
    observer.observe(element);
}

function getElementHeight(element) {
    return element.getBoundingClientRect().height;
}

