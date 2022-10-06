let {expect} = require("chai");
let {mathEnforcer} = require("../04.Math Enforcer");

describe('mathEnforcer', () => {
    describe('addFive', () => {
        it('should return correct result with a non-number parameter', () => {
            expect(mathEnforcer.addFive('STRING')).to.be.undefined;
        });

        it('should return correct result with integer number', () => {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });
        it('should return correct result with negative number', () => {
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        });
        it('should return correct result with floating number', () => {
            expect(mathEnforcer.addFive(5.5321321312312321)).to.be.closeTo(10.53, 0.01);
        });
    });

    describe('subtractTen', () => {
        it('should return correct result with a non-number parameter', () => {
            expect(mathEnforcer.subtractTen('STRING')).to.be.undefined;
        });

        it('should return correct result with integer number', () => {
            expect(mathEnforcer.subtractTen(5)).to.equal(-5);
        });
        it('should return correct result with negative number', () => {
            expect(mathEnforcer.subtractTen(-5)).to.equal(-15);
        });
        it('should return correct result with floating number', () => {
            expect(mathEnforcer.subtractTen(5.5321321312312321)).to.be.closeTo(-4.46, 0.01);
        });
    });

    describe('sum', () => {
        it('should return correct result with a non-number parameter', () => {
            expect(mathEnforcer.sum('STRING', 5)).to.be.undefined;
        });
        it('should return correct result with a non-number second parameter', () => {
            expect(mathEnforcer.sum(5, 'STRING')).to.be.undefined;
        });
        it('should return correct result with integer number', () => {
            expect(mathEnforcer.sum(5, 12)).to.equal(17);
        });
        it('should return correct result with negative number', () => {
            expect(mathEnforcer.sum(-5, -10)).to.equal(-15);
        });
        it('should return correct result with floating number', () => {
            expect(mathEnforcer.sum(5.5321321312312321, 4)).to.be.closeTo(9.53, 0.01);
        });
        it('should return correct result with 2 floating numbers', () => {
            expect(mathEnforcer.sum(5.5321321312312321, 4.23)).to.be.closeTo(9.76, 0.01);
        });
    });
})