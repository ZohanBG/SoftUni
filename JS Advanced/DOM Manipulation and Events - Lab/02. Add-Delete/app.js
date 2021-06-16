function addItem() {
    let textElement = document.getElementById('newItemText');
    let listElement = document.createElement('li');
    listElement.textContent = textElement.value;   
    let anchorElement = document.createElement('a');
    anchorElement.textContent = '[Delete]';
    anchorElement.setAttribute('href', '#');
    listElement.appendChild(anchorElement);
    let listElements = document.getElementById('items');
    listElements.appendChild(listElement);
    anchorElement.addEventListener('click', function(){
        anchorElement.parentElement.remove();
    });
    textElement.value = '';
}