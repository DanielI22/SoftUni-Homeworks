function calculator() {
    let a;
    let b;
    let c;
    return {
        'init': (input1, input2, result) => {
            a = document.querySelector(input1);
            b = document.querySelector(input2);
            c = document.querySelector(result);
        },
        'add': () => {
            c.value = +a.value + +b.value;
        },
        'subtract': () => {
            c.value = +a.value - +b.value;
        }
    }
}