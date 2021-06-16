function solve() {
   let buttonElements = document.querySelectorAll('.add-product');
   let textArea = document.querySelector('textarea');
   let items = [];
   let totalPrice = 0;
   for (const buttonElement of buttonElements) {
      buttonElement.addEventListener('click', function(e){
         let currentElement = e.currentTarget.parentElement.parentElement;
         let currentElementName = currentElement.querySelector('.product-title').textContent;
         let currentElementPrice = Number(currentElement.querySelector('.product-line-price').textContent);
         textArea.textContent += `Added ${currentElementName} for ${currentElementPrice.toFixed(2)} to the cart.\n`;
         if (!items.includes(currentElementName)) {
            items.push(currentElementName);
        }
         totalPrice += currentElementPrice;
      });
   }
   let checkoutElement = document.querySelector('.checkout');
   checkoutElement.addEventListener('click', function(){
      textArea.textContent += `You bought ${items.join(', ')} for ${totalPrice.toFixed(2)}.`;
      let buttons = Array.from(document.querySelectorAll('button'));
      buttons.forEach(button => button.disabled = true);
   });

}