function solve(input) {
    let catalog = {};
    let currentLetterProducts = [];
    for(element of input) {
        let [productName, productPrice] = element.split(' : ');
        productPrice = +productPrice;

        let currentProduct = {}
        currentProduct[productName] =  productPrice;

        if(!catalog.hasOwnProperty(productName[0])) {
            currentLetterProducts.push(currentProduct);
            catalog[productName[0]] = currentLetterProducts;
        }
    }

    console.log(catalog);
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
)