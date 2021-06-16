function focused() {
    let elements = document.getElementsByTagName('input');
    for (let element of elements) {
        element.addEventListener('focus',focuseElement);
        element.addEventListener('blur', unfocuseElement);
    }

    function focuseElement(event) {
        event.target.parentNode.className = 'focused';
    }

    function unfocuseElement(event) {
        event.target.parentNode.className = '';
    }
}
