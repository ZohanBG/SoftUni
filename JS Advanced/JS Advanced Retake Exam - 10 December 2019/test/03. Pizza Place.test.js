const { assert } = require("chai");
const pizzUni = require("../03. Pizza Place");


describe("Tests pizzaUni functionality", () => {

    describe("makeAnOrder", () => {

        it("trows an error if no pizza is ordered", function () {
            assert.throws(()=>{pizzUni.makeAnOrder(
                {orderedDrink: 'the name of the drink'})});
        });

        it("right output", function () {
            assert.equal(pizzUni.makeAnOrder({orderedPizza: 'luks', orderedDrink: 'cola'})
            ,`You just ordered luks and cola.`)
        });

        it("right output 2 ", function () {
            assert.equal(pizzUni.makeAnOrder({orderedPizza: 'luks'})
            ,`You just ordered luks`);
        });

    });

    describe("getRemainingWork", () => {

        it("right output", () => {
            assert.equal(pizzUni.getRemainingWork([{pizzaName: `the name of the pizza`, status: `ready`}
            ,{pizzaName: `pizza`, status: `preparing`}
            ,{pizzaName: `luks`, status: `preparing`}])
            ,`The following pizzas are still preparing: pizza, luks.`);    
        });

        it("right output", () => {
            assert.equal(pizzUni.getRemainingWork([{pizzaName: `the name of the pizza`, status: `ready`}
            ,{pizzaName: `pizza`, status: `ready`}
            ,{pizzaName: `luks`, status: `ready`}])
            ,'All orders are complete!');    
        });

    });

    describe("orderType", () => {

        it("right output", () => {
              assert.equal(pizzUni.orderType(10,'Carry Out'),9);
        });

        it("right output", () => {
            assert.equal(pizzUni.orderType(10,'Delivery'),10);
      });

    });

});
