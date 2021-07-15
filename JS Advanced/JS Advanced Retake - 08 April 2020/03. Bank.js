class Bank {
    constructor (bankName){
        this._bankName = bankName;
        this.allCustomers = [];
    }

    newCustomer (customer){
        if(this.allCustomers.some(x=>x["personalId"] == customer.personalId)){
            throw new Error(`${customer.firstName} ${customer.lastName} is already our customer!`)
        }
        
        this.allCustomers.push(customer);
        return customer;
    }

    depositMoney (personalId, amount){
        if(!this.allCustomers.some(x=>x["personalId"] == personalId)){
            throw new Error("We have no customer with this ID!");
        }

        let customer = this.allCustomers.find(x=>x["personalId"] == personalId);
        if(!customer.hasOwnProperty("totalMoney")){
            customer["totalMoney"] = 0;
        }
        if(!customer.hasOwnProperty("transactions")){
            customer["transactions"] = [];
        }
        customer["transactions"].push(`${customer.firstName} ${customer.lastName} made deposit of ${amount}$!`);
        customer["totalMoney"] += amount;
        return `${customer.totalMoney}$`;
    }

    withdrawMoney (personalId, amount){
        if(!this.allCustomers.some(x=>x["personalId"] == personalId)){
            throw new Error("We have no customer with this ID!");
        }
        let customer = this.allCustomers.find(x=>x["personalId"] == personalId);
        if(!customer.hasOwnProperty("totalMoney")){
            customer["totalMoney"] = 0;
        }

        if(customer.totalMoney < amount){
            throw new Error(`${customer.firstName} ${customer.lastName} does not have enough money to withdraw that amount!`)
        }

        if(!customer.hasOwnProperty("transactions")){
            customer["transactions"] = [];
        }

        customer["transactions"].push(`${customer.firstName} ${customer.lastName} withdrew ${amount}$!`)
        customer["totalMoney"] -= amount;

        return `${customer.totalMoney}$`
    }

    customerInfo (personalId){
        if(!this.allCustomers.some(x=>x["personalId"] == personalId)){
            throw new Error("We have no customer with this ID!");
        }
        let customer = this.allCustomers.find(x=>x["personalId"] == personalId);
        let result = `Bank name: ${this._bankName}\n`;
        result += `Customer name: ${customer.firstName} ${customer.lastName}\n`;
        result += `Customer ID: ${customer.personalId}\n`;
        result += `Total Money: ${customer.totalMoney}$\n`;
        result += `Transactions:\n`;
        let temp = [];
        for (let i = customer.transactions.length-1; i >= 0; i--) {
            temp.push(`${i+1}. `+customer.transactions[i]);
        }
        result +=temp.join("\n");
        result.trim();
        return result;
    }
}


let bank = new Bank('SoftUni Bank');


let customer1 = bank.newCustomer({ firstName: 'Svetlin', lastName: 'Nakov', personalId: 1111111 });


let customer2 = bank.newCustomer({ firstName: 'Mihaela', lastName: 'Mileva', personalId: 3333333 });

let totalMoney1 = bank.depositMoney(1111111, 250);


let totalMoney2 = bank.depositMoney(1111111, 250);


let totalMoney3 = bank.depositMoney(3333333, 555);


let totalMoney4 = bank.withdrawMoney(1111111, 125);

console.log(bank.customerInfo(1111111));



