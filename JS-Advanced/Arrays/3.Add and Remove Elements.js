function solve(array) {
    let arr = [...array];
    let init = 1;
    let result = [];
    for(let i = 0; i < arr.length; i++) {
        let command = arr[i];
        if(command === "add") {
            result.push(init);
        }
        else if(command === "remove") {
            result.pop();
        }
        init++;
    }
    if(result.length == 0) {
        console.log("Empty");
        return;
    }
    console.log(result.join('\n'));

}

solve(['add', 
'add', 
'remove', 
'add', 
'add']
);

solve(['remove', 
'remove', 
'remove']
)