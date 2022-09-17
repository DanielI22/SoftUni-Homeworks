function solve(arr){
    let result = [];
    arr.reduce((acc, val) => {
        if(val >= acc){
            result.push(val);
            acc = val;
        }

        return acc;
    }, Number.MIN_SAFE_INTEGER)
    return result;
}
solve([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
);