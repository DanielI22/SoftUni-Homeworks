let {expect} = require("chai");
let {lookupChar} = require("../03.Char Lookup");

describe('testUndefined', ()=> {
    it('should return undefiend when not string is passed', () => {
        let input = 2;
        let result = lookupChar(input, 4);
        expect(result).to.be.undefined;
    });
    it('should return undefiend when not integer index is passed', () => {
        let input = 2.5;
        let result = lookupChar("String", input);
        expect(result).to.be.undefined;
    });
})

describe('testInvalidIndex', () => {
    it('should return incorrect index when negative index is passed', () => {
        expect(lookupChar("String", -2)).to.equals('Incorrect index');
    });

    it('should return incorrect indxe when index is less than string length', () => {
        expect(lookupChar("LONG STRING", 20)).to.equals('Incorrect index');
    })
})

describe('testValidResult', () => {
    it('should return s with string string and index 0', () => {
        expect(lookupChar("string", 0)).to.equals('s');
    });
    it('should return g with string string and index 5', () => {
        expect(lookupChar("string", 5)).to.equals('g');
    });
})