export function saveToLocalStorage(key, data) {
    localStorage.setItem(key, data);
}

export function loadFromLocalStorage(key) {
    return localStorage.getItem(key);
}