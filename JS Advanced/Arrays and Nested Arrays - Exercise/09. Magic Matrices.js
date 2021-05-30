function solve(matrix) {
    let sums = [];
    for (let i = 0; i < matrix.length; i++) {
        let sum = 0 ;
        for (let j = 0; j < matrix[i].length; j++) {
              sum += matrix[i][j];
        }   
        sums.push(sum);
    }

    for (let j = 0; j < matrix[0].length; j++) {
        let sum = 0;
        for (let i = 0; i < matrix.length; i++) {
          sum+=matrix[i][j];
        }
        sums.push(sum);
    }

    let isMagical = true;

    for (let i = 1; i < sums.length; i++) {
        const element = sums[i];
        if(sums[0] !== element){
            isMagical = false;
            break;
        }
    }
    console.log(isMagical);
}

solve([[4, 5, 6],
    [6, 5, 4],
    [5, 6, 5]]
   );