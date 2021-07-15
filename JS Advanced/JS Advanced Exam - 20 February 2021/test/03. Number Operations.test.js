const numberOperations = require("../03. Number Operations_Resources");
const { assert } = require("chai");

describe("Tests", () => {
    describe("powerNumber", () => {
        it("right output", () => {
            assert.equal(numberOperations.powNumber(3), 9);
            assert.equal(numberOperations.powNumber(1), 1);
            assert.equal(numberOperations.powNumber(-5), 25);
            assert.equal(numberOperations.powNumber(11), 121);
            assert.equal(numberOperations.powNumber(-6), 36);
        });
    });
    describe("numberChecker", () => {
        it("right validation", () => {
            assert.throws(() => { numberOperations.numberChecker(NaN) }, 'The input is not a number!');
            assert.throws(() => { numberOperations.numberChecker('telve') }, 'The input is not a number!');
            assert.throws(() => { numberOperations.numberChecker(undefined) }, 'The input is not a number!');
        });
        it("right output1", () => {
            assert.equal(numberOperations.numberChecker(99), "The number is lower than 100!");
            assert.equal(numberOperations.numberChecker(55), "The number is lower than 100!");
            assert.equal(numberOperations.numberChecker(22), "The number is lower than 100!");
        });
        it("right output2", () => {
            assert.equal(numberOperations.numberChecker(100), "The number is greater or equal to 100!");
            assert.equal(numberOperations.numberChecker(200), "The number is greater or equal to 100!");
            assert.equal(numberOperations.numberChecker(333), "The number is greater or equal to 100!");
        });
    });
    describe("sumArrays", () => {
        it("right output1", () => {
            let array1 = [1, 2, 3];
            let array2 = [5, 11, 22];
            assert.deepEqual(numberOperations.sumArrays(array1, array2), [6, 13, 25]);
        });

        it("right output1", () => {
            let array1 = [1, 2, 3];
            let array2 = [5, 11, 22, 16, 22];
            assert.deepEqual(numberOperations.sumArrays(array1, array2), [6, 13, 25, 16, 22]);
        });

        it("right output1", () => {
            let array1 = [1, 2, 3, 3, 6, 22];
            let array2 = [5, 11, 22];
            assert.deepEqual(numberOperations.sumArrays(array1, array2), [6, 13, 25, 3, 6, 22]);
        });
    });
});
