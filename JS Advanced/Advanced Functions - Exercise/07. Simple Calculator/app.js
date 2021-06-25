function calculator() {
    let num1;
    let num2;
    let result;
    return{
        init(a, b, c){
            num1 = document.querySelector(a);
            num2 = document.querySelector(b);
            result = document.querySelector(c);
        },

        add(){ 
            result.value = Number(num1.value) + Number(num2.value); 
        },
        subtract () {
            result.value = Number(num1.value) - Number(num2.value); 
        }

    }
}

const calculate = calculator (); 
calculate.init ('#num1', '#num2', '#result');  



