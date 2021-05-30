function solve(array) {
    let result = [array[0]];
    for (let i = 1; i < array.length; i++) {
        if(result[result.length-1] <= array[i]){
            result.push(array[i]);
        }       
    }
    return result;
}

solve([20, 
    3, 
    2, 
    15,
    6, 
    1]
    );