function solve() {
    let url = 'http://localhost:3030/jsonstore/collections/students';

    fillData();

    document.getElementById('submit')
    .addEventListener('click', (e) => {
        e.preventDefault();
        let formElement = document.getElementById('form');
        let data = new FormData(formElement);

        if(data.get('firstName') == '' 
        || data.get('lastName') == '' 
        || data.get('facultyNumber') == '' 
        || data.get('grade') == ''){
            return;
        }

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application'
            },
            body: JSON.stringify({
                "firstName": data.get('firstName'),
                "lastName": data.get('lastName'),
                "facultyNumber": data.get('facultyNumber'),
                "grade": data.get('grade')
            })
        })
        .catch(err => console.log(err));

        formElement.reset();

        fillData();
    })

    function fillData() {
        fetch(url)
        .then(response => response.json())
        .then(data => {
            let tbodyElement = document.querySelector('#results tbody');
            while (tbodyElement.firstChild) {
                tbodyElement.removeChild(tbodyElement.firstChild);
            }
            for (const key in data) {
                let trElement = document.createElement('tr');

                let thFirstName = document.createElement('th');
                thFirstName.textContent = data[key].firstName;
                trElement.appendChild(thFirstName);

                let thLastName = document.createElement('th');
                thLastName.textContent = data[key].lastName;
                trElement.appendChild(thLastName);

                let thFacultyNumber = document.createElement('th');
                thFacultyNumber.textContent = data[key].facultyNumber;
                trElement.appendChild(thFacultyNumber);

                let thGrade = document.createElement('th');
                trElement.appendChild(thGrade);
                thGrade.textContent = data[key].grade;

                tbodyElement.appendChild(trElement);
            }
        })
        .catch(err => console.log(err));
    }
}

solve()