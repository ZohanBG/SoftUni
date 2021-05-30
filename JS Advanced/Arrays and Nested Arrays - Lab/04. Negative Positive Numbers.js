function solve(numbers) {
    
    let result = [];

    for (const number of numbers) {
        if(number >= 0){
            result.push(number)
        } else {
            result.unshift(number);
        }
    }
    
    for (const number of result) {
        console.log(number);
    }

}