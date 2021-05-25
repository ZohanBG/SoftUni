function solve(driverSpeed, area) {

    let speedLimit = 0;

    switch (area) {
        case 'motorway' : speedLimit = 130; break;
        case 'interstate' : speedLimit = 90; break;
        case 'city' : speedLimit = 50; break;
        case 'residential' : speedLimit = 20; break;              
    }

    if(speedLimit >= driverSpeed){
        console.log(`Driving ${driverSpeed} km/h in a ${speedLimit} zone`);
    } else {
        let difference = driverSpeed - speedLimit;
        let typeOfDifference = '';
        if (difference > 40 ) {
            typeOfDifference = 'reckless driving';
        } else if (difference >20) {
            typeOfDifference = 'excessive speeding';
        } else {
            typeOfDifference = 'speeding';
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${typeOfDifference}`);
    }
}

solve(200, 'motorway');