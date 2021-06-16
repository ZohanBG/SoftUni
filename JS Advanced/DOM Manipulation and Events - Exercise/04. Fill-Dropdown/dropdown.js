function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let optionElement = document.createElement('option');
    optionElement.textContent = textElement.value;
    optionElement.value = valueElement.value;
    let menuElement = document.getElementById('menu');
    menuElement.appendChild(optionElement);
    textElement.value = '';
    valueElement.value = '';
}