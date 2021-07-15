function loadCommits() {
    let ulElement = document.getElementById('commits');
    while (ulElement.firstChild) {
        ulElement.removeChild(ulElement.firstChild);
    }

    let username = document.getElementById('username').value;
    let repo = document.getElementById('repo').value;
    fetch(`https://api.github.com/repos/${username}/${repo}/commits`)
    .then(response => response.json())
    .then(data => {
        data.forEach(element => {
            let liElement = document.createElement('li');
            liElement.id = 'commits';
            liElement.textContent = `${element.commit.author.name}: ${element.commit.message}`;
            ulElement.appendChild(liElement);
        });
    })
    .catch(err => {
        let liElement = document.createElement('li');
        liElement.textContent = `Error: ${err.status} (Not Found)`;
    })
}