function solve(number, op1, op2, op3, op4, op5) {

    number = operation(number, op1);
    console.log(number);

    number = operation(number, op2);
    console.log(number);

    number = operation(number, op3);
    console.log(number);

    number = operation(number, op4);
    console.log(number);

    number = operation(number, op5);
    console.log(number);

    function operation(number, operation) {
        switch (operation) {
            case 'chop': number /= 2; break;
            case 'dice': number = Math.sqrt(number); break;
            case 'spice': number += 1; break;
            case 'bake': number *=3; break;
            case 'fillet': number -= number/5; break; 
        }
        return number;
    }
}

solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');
