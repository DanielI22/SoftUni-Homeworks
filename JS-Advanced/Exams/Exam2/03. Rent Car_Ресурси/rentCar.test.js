let {expect} = require("chai");
const { describe } = require("mocha");
let {rentCar} = require("../03. Rent Car_Ресурси/rentCar");

describe("Tests …", function() {
    describe("searchCar", function() {
        it("test", function() {
            expect(rentCar.searchCar(["A", "B"], "A")).to.equal(`There is 1 car of model A in the catalog!`);
        });
        it("test", function() {
            expect(rentCar.searchCar(["A", "A", "B"], "A")).to.equal(`There is 2 car of model A in the catalog!`);
        });
        it("test", function() {
            expect(() => rentCar.searchCar(["A", "A", "B"], "C")).to.throw('There are no such models in the catalog!');
        });
        it("test", function() {
            expect(() => rentCar.searchCar(3, 2)).to.throw("Invalid input!");
        });
     });

     describe("calculatePriceOfCar", function() {
        it("test", function() {
            expect(() => rentCar.calculatePriceOfCar(3, 2)).to.throw("Invalid input!");
        });
        it("test", function() {
            expect(() => rentCar.calculatePriceOfCar("A", 2)).to.throw('No such model in the catalog!');
        });
        it("test", function() {
            expect(rentCar.calculatePriceOfCar("Mercedes", 2)).to.equal("You choose Mercedes and it will cost $100!");
        });
     });

     describe("checkbudget", function() {
        it("test", function() {
            expect(() => rentCar.checkBudget(3, 2, "error")).to.throw("Invalid input!");
        });
        it("test", function() {
            expect(rentCar.checkBudget(1, 3,  2)).to.equal('You need a bigger budget!');
        });
        it("test", function() {
            expect(rentCar.checkBudget(1, 1,  8)).to.equal("You rent a car!");
        });
        it("test", function() {
            expect(rentCar.checkBudget(2, 2,  4)).to.equal("You rent a car!");
        });
     });
});
