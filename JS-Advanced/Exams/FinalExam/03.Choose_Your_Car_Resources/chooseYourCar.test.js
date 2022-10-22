let {expect} = require("chai");
let {chooseYourCar} = require("./chooseYourCar");

describe("Tests", function() {
    describe("choosingType", function() {
        it("test", function() {
            expect(() => chooseYourCar.choosingType('test', 'test', 1800)).to.throw("Invalid Year!");
        });
        it("test", function() {
            expect(() => chooseYourCar.choosingType('test', 'test', 2300)).to.throw("Invalid Year!");
        });
        it("test", function() {
            expect(() => chooseYourCar.choosingType('test', 'test', 1950)).to.throw("This type of car is not what you are looking for.");
        });
        it("test", function() {
            expect(chooseYourCar.choosingType('Sedan', 'test', 2022)).to.equal(`This test Sedan meets the requirements, that you have.`);
        });
        it("test", function() {
            expect(chooseYourCar.choosingType('Sedan', 'test', 2010)).to.equal(`This test Sedan meets the requirements, that you have.`);
        });
        it("test", function() {
            expect(chooseYourCar.choosingType('Sedan', 'test', 2005)).to.equal(`This Sedan is too old for you, especially with that test color.`);
        });
     });
     describe("brandName", function() {
        it("test", function() {
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], "test")).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.brandName("test", 1)).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 4)).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(chooseYourCar.brandName(["BMW", "Toyota", "Peugeot"], 2)).to.equal("BMW, Toyota");
        });
     });
     describe("CarFuelConsumption", function() {
        it("test", function() {
            expect(chooseYourCar.carFuelConsumption(100, 5)).to.equal("The car is efficient enough, it burns 5.00 liters/100 km.");
        });
        it("test", function() {
            expect(chooseYourCar.carFuelConsumption(100, 120)).to.equal("The car burns too much fuel - 120.00 liters!");
        });
        it("test", function() {
            expect(chooseYourCar.carFuelConsumption(100, 7)).to.equal("The car is efficient enough, it burns 7.00 liters/100 km.");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption(100, 'test')).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption('test', 120)).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption('test', 'test')).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption('test', -2)).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption(-5, 'test')).to.throw("Invalid Information!");
        });
        it("test", function() {
            expect(() => chooseYourCar.carFuelConsumption(-5, -2)).to.throw("Invalid Information!");
        });
     });
});
