const { assert } = require("chai");
const dealership = require("../03. Dealership");


// describe("Tests dealership functionality", function () {
    
//     describe("newCarCost", () => {

//         it("oldCar", () => {
//             assert.equal(100,dealership.newCarCost('Audi A4 B8', 15100));
//             assert.notEqual(200,dealership.newCarCost('Audi A4 B8', 15100));
//         });

//         it("newCar", () => {
//             assert.equal(15100,dealership.newCarCost('Audi A4 B9', 15100));
//             assert.notEqual(200,dealership.newCarCost('Audi A4 B9', 15100));
//         });

//     });

//     describe("carEquipment", () => {

//         it("validOutput", () => {
//             assert.deepEqual(["vrata", "prozorec", "volan"], 
//             dealership.carEquipment(["vrata", "klimatik", "prozorec", "dvigatel", "volan"],[0,2,4]));
//         });

//         it("notValidOutput", () => {
//             assert.notDeepEqual(["vrata", "prozorec", "volan"], 
//             dealership.carEquipment(["vrata", "klimatik", "prozorec", "dvigatel", "volan"],[0,1,4]));
//         });

//     });

//     describe("euroCategory", () => {

//         it("validOutput <4", () => {
//             assert.equal(dealership.euroCategory(3),'Your euro category is low, so there is no discount from the final price!');
//         });

//         it("validOutput >=4", () => {
//             assert.equal(dealership.euroCategory(4),'We have added 5% discount to the final price: 14250.');
//             assert.equal(dealership.euroCategory(5),'We have added 5% discount to the final price: 14250.');
//         });

//     });

// });
