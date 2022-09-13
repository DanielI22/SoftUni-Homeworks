function solve(...params) 
{   let type = params[0];
    let weight = params[1];
    let priceKg = params[2];
    let weightKg = (weight/1000);
    let price = (weightKg * priceKg);
    console.log(`I need $${price.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${type}.`);
}
solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);