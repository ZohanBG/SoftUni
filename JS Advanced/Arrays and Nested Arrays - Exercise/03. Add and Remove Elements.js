function solve(commands) {
    let array = [];
    let number = 0;
    commands.forEach(command => {
        number++;
        if(command === 'add'){
            array.push(number);
        }
        if(command === 'remove'){
            if(array.length >= 1){
                array.pop();
            }
        }
    });

    if(array.length === 0){
        console.log('Empty');
    } else {
        for (const number of array) {
            console.log(number);
        }
    }
    
}

solve(['add', 
'add', 
'remove', 
'add', 
'add']
);