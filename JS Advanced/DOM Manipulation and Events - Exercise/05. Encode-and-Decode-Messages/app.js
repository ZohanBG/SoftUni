function encodeAndDecodeMessages() {
    let [encodeButton , decodeButton] = document.querySelectorAll('div button');
    let [encodeTextArea, decodeTextArea] = document.querySelectorAll('div textarea');

    encodeButton.addEventListener('click',function(){
        let encodeText = encodeTextArea.value;
        let result = '';
        for (let i = 0; i < encodeText.length; i++) {
            result+=String.fromCharCode(encodeText.charCodeAt(i)+1);         
        }
        decodeTextArea.value = result;
        encodeTextArea.value = '';
    });

    decodeButton.addEventListener('click',function(){
        let decodeText = decodeTextArea.value;
        let result = '';
        for (let i = 0; i < decodeText.length; i++) {
            result+=String.fromCharCode(decodeText.charCodeAt(i)-1);         
        }
        decodeTextArea.value = result;
    });
}