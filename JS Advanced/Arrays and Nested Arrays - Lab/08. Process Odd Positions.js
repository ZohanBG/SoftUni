function solve(numbers) {
    return numbers.filter((a, i) => i%2 !==0).map(x => x*2).reverse().join(' ');
}