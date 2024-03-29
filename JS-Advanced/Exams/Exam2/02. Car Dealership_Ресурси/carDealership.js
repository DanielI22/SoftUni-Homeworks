class CarDealership {
    constructor(name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = [];
        this.totalIncome = 0;
    }

    addCar(model, horsepower, price, mileage) {
        if(!model || horsepower<0 || price <0 || mileage<0) {
            throw new Error("Invalid input!");
        }

        this.availableCars.push({
            model,
            horsepower,
            price,
            mileage
        });
        
        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    }

    sellCar(model, desiredMileage) {
        let car = this.availableCars.find(c => c.model == model);

        if(car === undefined) {
            throw new Error(`${model} was not found!`);
        }

        let price = car.price;
        let horsepower = car.horsepower;

        if(car.mileage <= desiredMileage) {
            price = car.price;
        }
        else if(car.mileage - desiredMileage <= 40000) {
            price = price*0.95;
        }
        else{
            price = price*0.9;
        }
        

        this.soldCars.push({
            model,
            horsepower,
            price
        });
        this.availableCars.filter(c => c.model !== model); //
        this.totalIncome+=price;
        return `${model} was sold for ${price.toFixed(2)}$`;
    }

    currentCar() {
        let result = this.availableCars.length > 0 ? "-Available cars:" : "There are no available cars";

        this.availableCars.forEach(car => {
            result += `\n---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$`;
        });

        return result;
    }

    salesReport(criteria) {
        if(criteria == "horsepower") {
            this.soldCars.sort((a,b) => b.horsepower - a.horsepower);
        }
        else if(criteria == "model") {
            this.soldCars.sort((a,b) => a.model.localeCompare(b.model));
        }
        else {
            throw new Error("Invalid criteria!");
        }

        let result = `-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`;
        result += `\n-${this.soldCars.length} cars sold:`;
        this.soldCars.forEach(car => {
            result+=`\n---${car.model} - ${car.horsepower} HP - ${car.price.toFixed(2)}$`;
        });

        return result;
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));



