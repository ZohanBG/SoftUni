function createTownPopulation(params) {
    const towns ={};
    params.forEach(param => {
        let [town, population] = param.split(" <-> ");
        population = Number(population);
        if(towns[town]){
            towns[town] += population;
        } else {
            towns[town] = population;
        }
    });

    for (const town in towns) {
        console.log(`${town} : ${towns[town]}`);
    }
   
}

console.log(createTownPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']

));