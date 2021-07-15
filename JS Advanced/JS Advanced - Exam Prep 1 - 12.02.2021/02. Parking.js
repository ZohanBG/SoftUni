class Parking{
    constructor(capacity){
        this.capacity = capacity;
        this.vehicles = [];
    }

    addCar(carModel, carNumber){
        if(this.vehicles.length == this.capacity){
            throw new Error("Not enough parking space.");        
        }

        let carObj = {
            carModel,
            carNumber,
            payed: false
        }

        this.vehicles.push(carObj);

        return `The ${carModel}, with a registration number ${carNumber}, parked.`;
    }

    removeCar(carNumber) {
        if(!this.vehicles.some(x=>x.carNumber == carNumber)){
            throw new Error("The car, you're looking for, is not found.");
        }

        let car = this.vehicles.find(x=>x.carNumber == carNumber);

        if(car.payed == false){
            throw new Error(`${carNumber} needs to pay before leaving the parking lot.`);
        }
        
        let index = this.vehicles.indexOf(car);

        this.vehicles.splice(index,1);

        return `${carNumber} left the parking lot.`;
    }

    pay(carNumber){
        if(!this.vehicles.some(x=>x.carNumber == carNumber)){
            throw new Error(`${carNumber} is not in the parking lot.`);
        }

        let car = this.vehicles.find(x=>x.carNumber == carNumber);

        if(car.payed == true){
            throw new Error(`${carNumber}'s driver has already payed his ticket.`);
        }

        car.payed = true;

        return `${carNumber}'s driver successfully payed for his stay.`;
    } 

    getStatistics(carNumber) {
        if(carNumber == undefined){
            let resultArray = [];
            resultArray.push(`The Parking Lot has ${this.capacity - this.vehicles.length} empty spots left.`)
            this.vehicles.sort((a,b) => a.carModel.localeCompare(b.carModel))
            .forEach(car => resultArray.push(`${car.carModel} == ${car.carNumber} - ${car.payed == true ? 'Has payed': 'Not payed'}`));
            return resultArray.join("\n");
        } else {
            let car = this.vehicles.find(x=>x.carNumber == carNumber);
            return `${car.carModel} == ${carNumber} - ${car.payed == true ? 'Has payed': 'Not payed'}`;
        }
    }
}

const parking = new Parking(12);

console.log(parking.addCar("Volvo t600", "TX3691CA"));
console.log(parking.addCar("asdvxcv", "TX3691bA"));
console.log(parking.addCar("bsd", "TX3691bv"));
console.log(parking.getStatistics());

console.log(parking.pay("TX3691CA"));
console.log(parking.removeCar("TX3691CA"));

