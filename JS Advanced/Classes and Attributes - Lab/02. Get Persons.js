function createPersonArray(){

    class Person{
        constructor(firstName, lastName, age, email){
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }
    
        toString(){
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    }
    
    let personArray = [];
    let person1 = new Person('Anna', 'Simpson',	22,	'anna@yahoo.com');
    let person2 = new Person('SoftUni');
    let person3 = new Person('Stephan', 'Johnson', 25);
    let person4 = new Person('Gabriel',	'Peterson',	24,	'g.p@gmail.com');
    personArray.push(person1);
    personArray.push(person2);
    personArray.push(person3);
    personArray.push(person4);
    return personArray;
}

console.log(JSON.stringify(createPersonArray()));
