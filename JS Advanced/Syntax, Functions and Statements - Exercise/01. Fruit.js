function solve(type, weigthInGr, price){
    let weigthInKg = weigthInGr/1000;
    console.log(`I need $${(price*weigthInKg).toFixed(2)} to buy ${(weigthInKg).toFixed(2)} kilograms ${type}.`);

}

solve('orange', 2500, 1.80)