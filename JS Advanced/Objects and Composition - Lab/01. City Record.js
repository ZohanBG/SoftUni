function createACity(name, population, treasury) {
    const city ={
        name,
        population,
        treasury
    };
    return city;
}

console.log(createACity('Tortuga',
7000,
15000
));