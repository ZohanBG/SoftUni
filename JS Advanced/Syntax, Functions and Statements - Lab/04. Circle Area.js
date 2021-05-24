function solve (value){
    if(typeof value === 'number'){
        console.log(((value*value)*Math.PI).toFixed(2));
    } else {
        console.log(`We can not calculate the circle area, because we receive a ${typeof value}.`);
    }
}

solve(5);