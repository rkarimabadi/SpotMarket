export function hideModal(modalId) {
    const modal = bootstrap.Modal.getInstance(document.getElementById(modalId));
    if (modal) {
        modal.hide();
    }
}
export function showBsModal(element) {
    const modal = new bootstrap.Modal(element);
    modal.show();
}

export function hideBsModal(element) {
    const modalInstance = bootstrap.Modal.getInstance(element);
    if (modalInstance) {
        modalInstance.hide();
    }
}