function car(obj) {
    let car = {};
    car.model = obj.model;
    delete obj.model;
    if(obj.power <= 90){
        car.engine = { power: 90, volume: 1800 };
    } else if (obj.power <= 120){
        car.engine = { power: 120, volume: 2400 };
    } else if (obj.power <= 200){
        car.engine = { power: 200, volume: 3500 };
    }
    delete obj.power;
    car.carriage =  { type: obj.carriage, color: obj.color };
    let weelSize = obj.wheelsize;
    if(weelSize % 2 == 0){
        weelSize--;
    }
    car.wheels = [weelSize, weelSize, weelSize, weelSize];
    return car;
}

console.log(car({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
));

