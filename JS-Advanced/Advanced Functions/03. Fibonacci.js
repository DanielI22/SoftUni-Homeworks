function getFibonator() {
    let fibe = 0;
    let fibe2 = 1;
    return function() {
        let result = fibe + fibe2;
        fibe = fibe2;
        fibe2 = result;
    return fibe;
    }
}
let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13