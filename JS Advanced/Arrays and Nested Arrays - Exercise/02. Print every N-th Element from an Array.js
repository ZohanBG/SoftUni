function solve(array, n) {
    return array.filter((a,i) => i % n === 0);
}

console.log(solve(['5', '20', '31', '4', '20'], 2));
