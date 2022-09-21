function solve(array) {
    let products = {};
    for(city of array) {
        let[cityName, product, price] = city.split(" | ");
        price = +price;
        if(!(product in products)) {
            products[product] = {price, cityName};
        }
        else if(price < products[product].price) {
            products[product].price = price;
            products[product].cityName = cityName;
        }
    }
    for(result in products) {
        console.log(`${result} -> ${products[result].price} (${products[result].cityName})`);
    }
}
    

solve([
    'Sofia City | Audi | 100000',
    'Sofia City | BMW | 100000',
    'Sofia City | Mitsubishi | 10000',
    'Sofia City | Mercedes | 10000',
    'Sofia City | NoOffenseToCarLovers | 0',
    'Mexico City | Audi | 1000',
    'Mexico City | BMW | 99999',
    'Mexico City | Mitsubishi | 10000',
    'New York City | Mitsubishi | 1000',
    'Washington City | Mercedes | 1000'
]
)