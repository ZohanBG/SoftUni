function solve(...arguments) {
    let result = [];
    let occurances = {};

    arguments.forEach(argument => {
        let type = typeof(argument);
        console.log(`${type}: ${argument}`);
        if(occurances[type] !== undefined){
            occurances[type]++;
        } else {
            occurances[type] = 1
        }
    });

    Object.keys(occurances)
    .sort((a,b)=> occurances[b]-occurances[a])
    .forEach(el => result.push(`${el} = ${occurances[el]}`));
    result.forEach(element => {
        console.log(element);

    });
}

solve('cat', 42, 32)

