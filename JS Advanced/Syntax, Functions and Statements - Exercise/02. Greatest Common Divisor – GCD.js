function solve(a,b){
    let gcd = 1;
    let min = Math.min(a,b);
    let max = Math.max(a,b);
    for (let i = 1; i <= min; i++){
        if(max%i == 0 && min%i == 0){
            gcd = i;
        } 
    }
    console.log(gcd);
}

solve(2154, 458)