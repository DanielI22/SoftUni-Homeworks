let {expect} = require("chai");
let {isOddOrEven} = require("../02.Even or Odd");

describe("testUndefined", ()=> {
    
    it('should return undefiend if number passed', () => {
        let input = 2;
        let result = isOddOrEven(input);
        expect(result).to.be.undefined;
    })

    it('should return undefiend if array passed', () => {
        let input = [1,2];
        let result = isOddOrEven(input);
        expect(result).to.be.undefined;
    })
})

describe("testOdd", ()=> {
    it('should return odd when odd length is passed', () => {
        let input = 'test2';
        let result = isOddOrEven(input);
        expect(result).to.equals('odd');
    })
})

describe("testEven", ()=> {
    it('should return even when even length is passed', () => {
        let input = 'test';
        let result = isOddOrEven(input);
        expect(result).to.equals('even');
    })

    it('should return even when empty is passed', () => {
        let input = '';
        let result = isOddOrEven(input);
        expect(result).to.equals('even');
    })
})