function solve(matrix) {
    let mainDiagonal = 0;
    let secondaryDiagonal = 0;
    let mainDiagonalIndex = 0;
    let secondaryDiagonalIndex = matrix.length - 1; 
    matrix.forEach(array => {
        mainDiagonal += array[mainDiagonalIndex++];
        secondaryDiagonal += array[secondaryDiagonalIndex--];
    });
    console.log(mainDiagonal);
    console.log(secondaryDiagonal);
}

solve([[20, 40],
       [10, 60]]);