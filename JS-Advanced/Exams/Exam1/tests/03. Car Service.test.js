let {expect, assert} = require("chai");
let {carService} = require("../03. Car Service_Resources");

describe("Tests …", function() {
    describe("isItExpensive", function() {
        it("test", function() {
            expect(carService.isItExpensive("Engine")).to.equal("The issue with the car is more severe and it will cost more money");
        });
        it("test", function() {
            expect(carService.isItExpensive("Transmission")).to.equal("The issue with the car is more severe and it will cost more money");
        });
        it("test", function() {
            expect(carService.isItExpensive("Test")).to.equal("The overall price will be a bit cheaper");
        });
     });
     describe("discount", function() {
        it("test", function() {
            expect(carService.discount(3, 10)).to.be.equal(`Discount applied! You saved ${10*0.15}$`);
        });
        it("test", function() {
            expect(carService.discount(7, 10)).to.be.equal(`Discount applied! You saved ${10*0.15}$`);
        });
        it("test", function() {
            expect(carService.discount(8, 10)).to.be.equal(`Discount applied! You saved ${10*0.3}$`);
        });
        it("test", function() {
            expect(carService.discount(2, 10)).to.be.equal("You cannot apply a discount");
        });
        it("s", function() {
            expect(() => carService.discount("2", "10")).throw("Invalid input");
        });
     });

     describe("partsToBuy", function() {
        it("test", function() {
            expect(carService.partsToBuy([], [])).to.equal(0);
        });
        it("test", function() {
            expect(carService.partsToBuy(
                [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 } ],
                ["blowoff valve"])).to.equal(145);
        });
        it("adsad", function() {
            expect(() => carService.partsToBuy(["test"], 1)).to.throw("Invalid input");
        });
     });
});
