function catalogue(input) {
 
    let products = [];
 
    for (let i = 0; i < input.length; i++) {
        products.push(input[i].split(" :")
            .join(":"));
    }
 
    products.sort();
 
    let firstLetter = "";
    for (let product of products) {
        if (firstLetter !== product.charAt(0)) {
            firstLetter = product.charAt(0);
            console.log(firstLetter);
        }
 
        console.log("  " + product);
    }
}

catalogue(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
)