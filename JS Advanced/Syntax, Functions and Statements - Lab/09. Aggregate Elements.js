function solve(params){
    let result1 = 0;
    let result2 = 0;
    let result3 = '';

    params.forEach(element => {
        result1 += element;
        result2 += 1/element;
        result3 +=element
    }); 
    console.log(result1);
    console.log(result2);
    console.log(result3);

}

solve([2, 4, 8, 16])