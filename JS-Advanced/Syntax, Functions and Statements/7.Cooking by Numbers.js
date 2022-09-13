function solve(num, op1, op2, op3, op4, op5) {
    let number = Number(num);
    let operations = [op1, op2, op3, op4, op5];

    for(let i = 0; i < 5; i++) {
        let currentOp = operations[i];

        if(currentOp === 'chop') {
            number = number / 2;
        }
        else if(currentOp === 'dice') {
            number = Math.sqrt(number);
        }
        else if(currentOp === 'spice') {
            number++;
        }
        else if(currentOp === 'bake') {
            number = number * 3;
        }
        else if(currentOp === 'fillet') {
            number = number * 0.8;
        }

        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');