function add(a) {
    let sum = a;

    function calc(b) {
        sum += b;
        return calc;
    }
    calc.toString = () => sum;
    return calc;
}

console.log(add(4)(3).toString());