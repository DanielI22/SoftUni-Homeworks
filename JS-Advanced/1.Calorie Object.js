function solve(array) {
    let fruit = {};

    for(let i=0; i<array.length; i+=2) {
 
        fruit[array[i]] = Number(array[i+1]);
    }

    console.log(fruit);
}

solve(['Yoghurt', '48', 'Rise', '138', 'Apple', '52'])