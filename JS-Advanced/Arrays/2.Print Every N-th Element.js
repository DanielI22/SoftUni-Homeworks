function solve(arr, number) {
    let array = [...arr];
    let result = [];
    let j = 0;
    for(let i = 0; i < array.length; i+=number){
        result[j] = array[i];
        j++;
    }
    return result;
}
solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
);