function storeCatalog(input) {
 
    input.sort((a, b) => a.localeCompare(b));
    for (let index = 0; index < input.length;) {
        let letter = input[index][0];
        console.log(letter);
 
        while (input[index] && input[index][0] === letter) {
            let [a, b] = input[index].split(' : ');
            console.log(`  ${a}: ${b}`);
            index++;
        }
    }
}

storeCatalog(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);