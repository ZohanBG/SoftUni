function solve(n, k) {   
    let numbers = [1];
    for (let i = 0; i < n - 1 ; i++) {

        let sum = 0;

        for (let j = i - k + 1; j <= i ; j++) {
            if(j>=0){
                sum+= Number(numbers[j]);
            }
        }

        numbers.push(sum);

    }

    return numbers;

}