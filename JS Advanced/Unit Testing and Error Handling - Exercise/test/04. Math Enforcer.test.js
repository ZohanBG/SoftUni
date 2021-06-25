const {assert, expect} = require('chai');
const mathEnforcer = require('../04. Math Enforcer');

describe('Testing math enforser functionallity', ()=>{
    describe('Testing addFive functionallity', ()=>{
        it('Should return undefined with wrong input',()=>{
            assert.equal(mathEnforcer.addFive('string'), undefined);
            assert.equal(mathEnforcer.addFive(null), undefined);
            assert.equal(mathEnforcer.addFive(undefined), undefined);
        });
        it('Should addFive to right input',()=>{
            assert.equal(mathEnforcer.addFive(5), 10);
            assert.equal(mathEnforcer.addFive(0,0001), 5,0001);
            assert.equal(mathEnforcer.addFive(-5),0);
            expect(mathEnforcer.addFive(-5.001)).equal(-5.001+5);
            assert.closeTo(mathEnforcer.addFive(-5.0001),0,0.01);
        });
    });

    describe('Testing subtractTen functionallity', ()=>{
        it('Should return undefined with wrong input',()=>{
            expect(mathEnforcer.subtractTen(10.001)).equal(10.001-10);
            assert.equal(mathEnforcer.subtractTen('string'), undefined);
            assert.equal(mathEnforcer.subtractTen(null), undefined);
            assert.equal(mathEnforcer.subtractTen(undefined), undefined);
        });
        it('Should subtractTen to right input',()=>{
            assert.equal(mathEnforcer.subtractTen(5), -5);
            let result = mathEnforcer.subtractTen(0,0001);
            assert.closeTo(result, -10, 0.01);
            assert.equal(mathEnforcer.subtractTen(-10),-20);
        });
    });

    describe('Testing sum functionallity', ()=>{
        it('Should return undefined with wrong input',()=>{
            assert.equal(mathEnforcer.sum('',5), undefined);
            assert.equal(mathEnforcer.sum(null,5), undefined);
            assert.equal(mathEnforcer.sum(5,''), undefined);
            assert.equal(mathEnforcer.sum(5,null), undefined);
        });
        it('Should return undefined with wrong input 2 ',()=>{
            assert.equal(mathEnforcer.sum('',''), undefined);
            assert.equal(mathEnforcer.sum(null,''), undefined);
            assert.equal(mathEnforcer.sum(null,null), undefined);
            assert.equal(mathEnforcer.sum(5,undefined), undefined);
            assert.equal(mathEnforcer.sum(undefined,5), undefined);
            assert.equal(mathEnforcer.sum(undefined,undefined), undefined);
        });
        it('Should sum to right input',()=>{ 
            assert.equal(mathEnforcer.sum(5,6), 11);
            expect(mathEnforcer.sum(5.0001,3.0001)).equal(5.0001+3.0001);
            assert.closeTo(mathEnforcer.sum(5.5,5.31),10.81,0.01);   
            assert.equal(mathEnforcer.sum(-5,-10),-15); 
        });
    });
})