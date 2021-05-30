function solve(array, times) {
    for (let i = 0; i < times; i++) {
        array.unshift(array.pop());
    }
    console.log(array.join(' '));
}

solve(['1', 
'2', 
'3', 
'4'], 
2
);