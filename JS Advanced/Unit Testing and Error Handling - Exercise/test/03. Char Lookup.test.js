// const lookupChar = require('../03. Char Lookup');
// const {assert} = require('chai');

// describe('Testing lookupChar functionallity',()=>{
//     it('Should return undefined if first input is wrong',()=>{
//         assert.equal(lookupChar(5,5), undefined);
//     });

//     it('Should return undefined if first input is wrong 2 ',()=>{
//         assert.equal(lookupChar(null,5), undefined);
//     });

//     it('Should return undefined if second input is wrong ',()=>{
//         assert.equal(lookupChar('abc',3.14), undefined);
//     });

//     it('Should return undefined if second input is wrong ',()=>{
//         assert.equal(lookupChar('abc','cda'), undefined);
//     });

//     it('Should return Incorrect index if index is out of bounds',()=>{
//         assert.equal(lookupChar('abc',10), "Incorrect index");
//     });

//     it('Should return Incorrect index if index is out of bounds',()=>{
//         assert.equal(lookupChar('abc',-2), "Incorrect index");
//     });

//     it('Should return correct result ',()=>{
//         assert.equal(lookupChar('abc',2), 'c');
//     });
// })
