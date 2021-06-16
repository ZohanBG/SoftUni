function validate() {
    let inputElement = document.getElementById('email');
    inputElement.addEventListener('change', function(){
        let textContent = inputElement.value;
        let output = textContent.match(/^[a-z]+@[a-z]+.[a-z]+$/gm);
        if(output == null){
            inputElement.classList.add("error");
        } else {
            inputElement.removeAttribute('class');
        }       
    });
}