function solve(params) {
    let array = [];
    params.forEach(element => {
        if(element == 'print'){
            console.log(array.join(","));
        } else{
            let[command, item] = element.split(" ");
            if(command == 'add'){
                array.push(item);
            } else if (command =="remove"){
                array = array.filter(x=>x != item);
            }
        }
    });
}

solve(['add pesho', 'add george', 'add peter', 'add peter','add peter','add peter','remove peter','print']);