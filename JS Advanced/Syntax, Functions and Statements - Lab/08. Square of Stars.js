function solve(num){   
    if(num == null){
        num = 5;

    }
    let side = Number(num);
    for(let i = 0 ; i < side ; i++){
        console.log('* '.repeat(side));
    }  
}

solve ();