function extractText() {
    let text = document.querySelectorAll('#items li');
    let output = document.querySelector('#result')
    for (const iterator of text) {
        output.textContent +=iterator.textContent.trim()+"\n";
    }
}