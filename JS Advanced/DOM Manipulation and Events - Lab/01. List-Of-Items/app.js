function addItem() {
    let textElement = document.getElementById('newItemText');
    let newElement = document.createElement('li');
    newElement.textContent = textElement.value;
    let listElements = document.getElementById('items');
    listElements.appendChild(newElement);
    textElement.value = '';
}