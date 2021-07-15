function loadRepos() {
   fetch('https://api.github.com/users/testnakov/repos')
   .then(response => response.json())
   .then(data => {
      let divElement = document.getElementById('res');
      divElement.textContent = data;     
      console.log(data); 
   })
   .catch(error => console.log(error));
}