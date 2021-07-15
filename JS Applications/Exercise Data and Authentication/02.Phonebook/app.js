function attachEvents() {
    let url = 'http://localhost:3030/jsonstore/phonebook';
    document.getElementById('btnLoad')
    .addEventListener('click', () => {
        fetch(url)
        .then(response => response.json())
        .then(data => {
            let ulElement = document.getElementById('phonebook');
            while (ulElement.firstChild) {
                ulElement.removeChild(ulElement.firstChild);
            }
            for (const key in data) {
                let liElement = document.createElement('li');
                liElement.textContent = `${data[key].person}: ${data[key].phone}`;
                let deleteButton  = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.addEventListener('click', () => {
                    fetch(`${url}/${data[key]._id}`, {
                        method: 'DELETE'
                    });
                    ulElement.removeChild(liElement);
                })
                liElement.appendChild(deleteButton);
                ulElement.appendChild(liElement);
            }
        })
        .catch(err => console.log(err));
    })

    document.getElementById('btnCreate')
    .addEventListener('click', () => {
        let person = document.getElementById('person');
        let phone = document.getElementById('phone');
        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type' : 'application'
            },
            body: JSON.stringify({
                'person': person.value,
                'phone': phone.value
            }) 
        })
        person.value = '';
        phone.value = '';
    });
}

attachEvents();