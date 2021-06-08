function solve(input) {
    let output =[];
    input.forEach(character => {
        let obj = {};
        let info = character.split(' / ');
        obj.name = info[0];
        obj.level = Number(info[1]);
        obj.items = info[2]? info[2].split(', ') :[];
        output.push(obj)
    });
    return JSON.stringify(output);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));
