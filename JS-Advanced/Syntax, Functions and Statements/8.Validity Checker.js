function solve(x1, y1, x2, y2) {
    function validate(x1, y1, x2, y2) {
        let formula = Math.sqrt(Math.pow(x2-x1, 2) + Math.pow(y2-y1, 2));
        if(Number.isInteger(formula)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`);
        }
        else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`);
        }
    }

    validate(x1, y1, 0, 0);
    validate(x2, y2, 0, 0);
    validate(x1, y1, x2, y2);
}

solve(3, 0, 0, 4)
solve(2, 1, 1, 1)