function attachEvents() {
    let selectElement = document.getElementById('posts');
    let comments = document.getElementById('post-comments');
    document.getElementById('btnLoadPosts')
    .addEventListener('click', () => {
        fetch('http://localhost:3030/jsonstore/blog/posts')
        .then(response => response.json())
        .then(data => {
            for (const key in data) {
                let optionElement = document.createElement('option');
                optionElement.value = data[key].id;
                optionElement.textContent = data[key].title.toUpperCase();
                selectElement.appendChild(optionElement);
            }
        })
        .catch(err => console.log(err));
    })

    document.getElementById('btnViewPost')
    .addEventListener('click', () => {
        let selectedOption = selectElement.options[selectElement.selectedIndex].value;
        fetch(`http://localhost:3030/jsonstore/blog/posts/${selectedOption}`)
        .then(response => response.json())
        .then(data =>{
            
            document.getElementById('post-title').textContent = data.title;
            document.getElementById('post-body').textContent = data.body;
            return fetch('http://localhost:3030/jsonstore/blog/comments')
        })
        .then(response => response.json())
        .then(data => {
            while (comments.firstChild) {
                comments.removeChild(comments.firstChild);
            }
            for (const key in data) {
                if(data[key].postId == selectedOption){
                    let liElement = document.createElement('li');
                    liElement.textContent = data[key].text;
                    liElement.id = data[key].id;
                    comments.appendChild(liElement);
                }
            }
        })
        .catch(err => console.log(err))
    })
}

attachEvents();