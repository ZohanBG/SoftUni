function solve(array) {
    array.sort((a, b) => {
        if(a.length > b.length){
            return 1;
        } else if (a.length < b.length){
            return -1;
        } else {
            return a.localeCompare(b);
        }
    });

    for (const element of array) {
        console.log(element);
    } 
}

solve(['test', 
'Deny', 
'omen', 
'Default']
)