function solve(arr, number) {
    let array = [...arr];
    for(let i = 0; i < number; i++) {
        let shifter = array.pop();
        array.unshift(shifter);
    }
    console.log(array.join(' '));
}
solve(['1', 
'2', 
'3', 
'4'], 
2
);