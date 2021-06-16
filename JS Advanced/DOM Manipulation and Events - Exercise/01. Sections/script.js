function create(words) {
   let startingDivElement = document.querySelector('div');
   words.forEach(word => {
      let wordDivElement = document.createElement('div');
      let paragraphElement = document.createElement('p');
      paragraphElement.textContent = word;
      paragraphElement.style.display = 'none';
      wordDivElement.appendChild(paragraphElement);
      startingDivElement.appendChild(wordDivElement);
      wordDivElement.addEventListener('click', function(){
         wordDivElement.querySelector('p').style.display = 'block';
      });
      wordDivElement.setAttribute('id', "content");
   });
}