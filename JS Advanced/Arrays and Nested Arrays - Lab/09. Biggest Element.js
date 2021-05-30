function solve(numbers) {
    let max = Number.NEGATIVE_INFINITY;
    numbers.forEach(array => {
        array.forEach(element => {
            if(max < element){
                max = element;
            }
        });
    });
    console.log(max);
}

solve([[20, 50, 10],[8, 33, 145]]);