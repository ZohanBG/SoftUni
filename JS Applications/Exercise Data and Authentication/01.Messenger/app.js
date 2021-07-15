function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/messenger';

    document.getElementById('refresh')
    .addEventListener('click', () => {
        fetch(url)
        .then(response => response.json())
        .then(data => {
            let outputArea = document.getElementById('messages');
            outputArea.textContent = '';
            for (const key in data) {
                outputArea.textContent += `${data[key].author}: ${data[key].content}\n`;
            }
            outputArea.textContent.trimEnd();
        })
        .catch(err => console.log(err));
    });

    document.getElementById('submit')
    .addEventListener('click', () => {
        let author = document.querySelector('input[name="author"]');
        let content = document.querySelector('input[name="content"]');
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application'
            },
            body : JSON.stringify({
                'author' : author.value,
                'content' : content.value
            })
        })
        .catch(err => console.log(err));
        author.value = '';
        content.value = '';
    })
}

attachEvents();