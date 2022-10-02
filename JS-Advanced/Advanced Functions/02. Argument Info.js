function solve(...args) {
    let array = args;
    let typesArr = {};
    for(let arg of array) {
        let type = typeof arg;
        console.log(`${type}: ${arg}`);

        if(type in typesArr) {
            typesArr[type]++;
        }
        else {
            typesArr[type] = 1;
        }
    }

    let sorted = [];
    for (let key in typesArr) {
        sorted.push([key, typesArr[key]]);
    }
    sorted.sort((a,b) => b[1] - a[1]);

    for(var i = 0; i < sorted.length; i++) {
        console.log(`${sorted[i][0]} = ${sorted[i][1]}`);
    }
}

solve('cat', 42, 23, function () { console.log('Hello world!'); })