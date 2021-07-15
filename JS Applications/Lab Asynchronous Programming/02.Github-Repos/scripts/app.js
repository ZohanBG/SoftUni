function loadRepos() {
	let ulElement = document.getElementById('repos');
	while (ulElement.firstChild) {
        ulElement.removeChild(ulElement.firstChild);
    }
	let name = document.getElementById('username').value;
	fetch(`https://api.github.com/users/${name}/repos`)
	.then(response => response.json())
	.then(data => {
		data.forEach(element => {
			let liElement = document.createElement('li');
		    liElement.id = 'repos';
		    let aElement = document.createElement('a');
		    aElement.textContent = element['full_name'];
			aElement.href = element['html_url'];
			liElement.appendChild(aElement);
			ulElement.appendChild(liElement);
		})
	})
	.catch(error => {
		let liElement = document.createElement('li');
		liElement.id = 'repos';
		let aElement = document.createElement('a');
		aElement.textContent = error;
		liElement.appendChild(aElement);
		ulElement.appendChild(liElement);
	});
	
}