function solve(numbers) {
    numbers.sort((a,b) => a-b);
    let result = [];
    while(numbers.length > 0){
        result.push(numbers.shift());
        if(numbers.length > 0){
            result.push(numbers.pop());
        }
    }
    return result;
}

solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]);