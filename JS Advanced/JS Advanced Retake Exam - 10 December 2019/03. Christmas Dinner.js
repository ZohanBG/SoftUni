class ChristmasDinner {
    constructor(budget){
        if (budget < 0) {
            throw new Error('The budget cannot be a negative number');
        }
        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(product){
        let [name,price] = product;
        if(price > this.budget){
            throw new Error("Not enough money to buy this product");
        }
        this.products.push(name);
        this.budget -=price;
        return `You have successfully bought ${name}!`;
    }

    recipes(recipe){
        let ingredients = recipe.productsList;
        let bool = true;
        ingredients.forEach(ingredient => {
            if(!this.products.includes(ingredient)){
                bool = false;
            }
        });

        if(bool){
            this.dishes.push(recipe);
            return `${recipe.recipeName} has been successfully cooked!`;
        } else {
            throw new Error("We do not have this product");
        }
    }

    inviteGuests(name, dish){
        if(!this.dishes.some(x=>x.recipeName == dish)){
            throw new Error("We do not have this dish");
        }

        if(this.guests.hasOwnProperty(name)){
            throw new Error("This guest has already been invited");
        } else {
            this.guests[name] = dish;
            return `You have successfully invited ${name}!`;
        }
    }

    showAttendance(){
        let resultArray =[];
        for (const key in this.guests) {
            let thisDish;
            this.dishes.forEach(dish => {
                if(dish.recipeName == this.guests[key]){
                    thisDish = dish;
                }
            });
            let temp = `${key} will eat ${this.guests[key]}, which consists of ${thisDish.productsList.join(", ")}`;
            resultArray.push(temp);
        }
        return resultArray.join("\n");
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Fruits', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Rice', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());


