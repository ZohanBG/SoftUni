function solve(array, typeSort) {
    if(typeSort == 'asc'){
        array = array.sort((a,b) => a-b);
    } else {
        array = array.sort((a,b) => b-a);
    }
    return array;
}

solve([14, 7, 17, 6, 8], 'desc')