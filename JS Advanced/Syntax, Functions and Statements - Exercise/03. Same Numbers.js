function solve(num) {
    let sum = 0;
    let isSame = true;
    let numString = String(num);
    for (let i = 0; i < numString.length-1; i++) {
        sum += Number(numString[i]);
        if(numString[i] != numString[i+1]){
            isSame=false;
        }        
    }
    sum += Number(numString[numString.length-1]);
    console.log(isSame);
    console.log(sum);
}

solve(1234)