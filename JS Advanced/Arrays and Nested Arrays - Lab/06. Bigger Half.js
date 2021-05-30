function solve(numbers) {
    numbers.sort((a, b) => a - b);
    let start = Math.floor(numbers.length/2);
    let secondHalf = numbers.slice(start, numbers.length);
    return secondHalf;
}