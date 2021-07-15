function solution() {
    fetch('http://localhost:3030/jsonstore/advanced/articles/list')
        .then(response => response.json())
        .then(data => {
            data.forEach(article => {
                let accordionDivElement = document.createElement('div');
                accordionDivElement.classList.add('accordion');

                let headDivElement = document.createElement('div');
                headDivElement.classList.add('head');

                let titleSpanElement = document.createElement('span');
                titleSpanElement.textContent = article.title;
                headDivElement.appendChild(titleSpanElement);

                let buttonElement = document.createElement('button');
                buttonElement.classList.add('button');
                buttonElement.id = article["_id"];
                buttonElement.textContent = 'More'
                headDivElement.appendChild(buttonElement);
                accordionDivElement.appendChild(headDivElement);
                let extraDivElement = document.createElement('div');
                extraDivElement.classList.add('extra');
                accordionDivElement.appendChild(extraDivElement);

                document.getElementById('main').appendChild(accordionDivElement);

                buttonElement.addEventListener('click', () => {
                    let id = buttonElement.id;
                    fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`)
                        .then(response => response.json())
                        .then(data => {
                            if (buttonElement.textContent == 'More') {
                                while (extraDivElement.firstChild) {
                                    extraDivElement.removeChild(extraDivElement.firstChild);
                                }
                                let pElement = document.createElement('p');
                                pElement.textContent = data.content;
                                extraDivElement.appendChild(pElement);
                                extraDivElement.style.display = 'block';
                                buttonElement.textContent = 'Less';

                            } else {
                                extraDivElement.style.display = 'none';
                                buttonElement.textContent = 'More';

                            }

                        })
                        .catch(err => console.log(err));
                })
            })
            .catch(err => console.log(err));
    });
}

solution()