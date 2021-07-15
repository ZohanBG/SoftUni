function solve() {
    let url = 'http://localhost:3030/jsonstore/collections/books';
    let form = document.querySelector('form');
    let formH3 = form.querySelector('h3');
    let editedBookId = '';

    document.getElementById('loadBooks')
    .addEventListener('click', () => {

        let tbody = document.querySelector('table tbody');
        while (tbody.firstChild) {
            tbody.removeChild(tbody.firstChild);
        }

        fetch(url)
        .then(response => response.json())
        .then(data => {

            for (const key in data) {
                let tr = document.createElement('tr');

                let titleTd = document.createElement('td');
                titleTd.textContent = data[key].title;
                tr.appendChild(titleTd);

                let authorTd = document.createElement('td');
                authorTd.textContent = data[key].author;
                tr.appendChild(authorTd)

                let actionTd = document.createElement('td');

                let editButton = document.createElement('button');
                editButton.textContent = 'Edit';
                actionTd.appendChild(editButton);

                editButton.addEventListener('click', () => {
                    formH3.textContent = 'Edit FORM';
                    form.elements['title'].value = data[key].title;
                    form.elements['author'].value = data[key].author;
                    editedBookId = key;
                });

                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                actionTd.appendChild(deleteButton);

                deleteButton.addEventListener('click', () => {
                    fetch(`${url}/${key}`,{
                        method: 'Delete'
                    })
                    .catch(err => console.log(err));

                    tbody.removeChild(tr);

                });

                tr.appendChild(actionTd);
                tbody.appendChild(tr);           
            }
        })
        .catch(err => console.log(err));
    });

    document.querySelector('form button')
    .addEventListener('click', (e) => {
        e.preventDefault();

        let data = new FormData(form);

        if(data.get('author') == '' || data.get('title') == '' ){
            return;
        }

        if(formH3.textContent == 'FORM'){
            fetch(url, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application'
                },
                body: JSON.stringify({
                    "author": data.get('author'),
                    "title": data.get('title')
                })
            })
            .catch(err => console.log(err));

            form.reset();

        } else {
            fetch(`${url}/${editedBookId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application'
                },
                body: JSON.stringify({
                    "author": data.get('author'),
                    "title": data.get('title')
                })
            })
            .catch(err => console.log(err));

            form.reset();
        }
    })
}

solve();
