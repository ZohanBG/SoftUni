function solve(input) {
    let output = [];
    let [town, lati, long] = input[0].split(/\s*\|\s*/gim)
    .filter(x => x!=='')
    .map(x => isNaN(Number(x)) ? x : Number(Number(x).toFixed(2)));
    for (let i = 1 ; i < input.length; i++) {
        let [townInfo, latiInfo, longInfo] = input[i].split(/\s*\|\s*/gim)
        .filter(x => x!=='')
        .map(x => isNaN(Number(x)) ? x : Number(Number(x).toFixed(2)));
        let currentTown = {};
        currentTown[town] = townInfo;
        currentTown[lati] = latiInfo;
        currentTown[long] = longInfo;
        output.push(currentTown); 
    }
    return  JSON.stringify(output);
}
 
console.log(solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
));
