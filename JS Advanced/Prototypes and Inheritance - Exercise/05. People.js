function solution() {
    class Employee {
        constructor(name, age, tasks) {
            if (this.constructor === Employee) {
                throw new Error("Can't instantiate abstract class!");
            }
            this.name = name;
            this.age = age;
            this.tasks = tasks;
            this.salary = 0;
            this._currentIndex = 0;
        }

        work() {
            let currentTask = this.tasks[this._currentIndex].replace("{employee name}", this.name);
            console.log(currentTask);
            this._currentIndex++;
            if (this._currentIndex >= this.tasks.length) {
                this._currentIndex = 0;
            }
        }

        _getSalary(){
            return this.salary;
        }

        collectSalary() {
            console.log(`${this.name} received ${this._getSalary()} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age, ["{employee name} is working on a simple task."]);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age, ["{employee name} is working on a complicated task.",
                "{employee name} is taking time off work.",
                "{employee name} is supervising junior workers."
            ]);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age, ["{employee name} scheduled a meeting.",
            "{employee name} is preparing a quarterly report."    
            ]);
            this.dividend = 0;
        }

        _getSalary(){
            return this.salary + this.dividend;
        }
    }

    return {
        Employee,
        Junior,
        Senior,
        Manager
    }
}

const classes = solution (); 
 
const manager = new classes.Manager('Tom', 55); 
 
manager.salary = 15000; 
manager.collectSalary();  
manager.dividend = 2500; 
manager.collectSalary();  
 


