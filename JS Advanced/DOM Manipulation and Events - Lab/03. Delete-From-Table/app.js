function deleteByEmail() {
    let tableElements = document.querySelectorAll('tbody tr');
    let textContent = document.querySelector('label input').value;
    let resultElement = document.getElementById('result');
    for (const iterator of tableElements) {
        if(iterator.children[1].textContent == textContent){
            iterator.remove();
            resultElement.textContent = 'Deleted.';
            return;
        } 
    }
    resultElement.textContent = 'Not found.';
}