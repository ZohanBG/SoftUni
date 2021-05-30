function solve(numbers) {

    let output = '';

    for (let i = 0; i < numbers.length; i+=2) {
        output += numbers[i] + ' ';
    }

    console.log(output);
}
