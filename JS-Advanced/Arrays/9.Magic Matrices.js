function solve(multiArray) {
    let magicSum = 0;
    let currentSum = 0;
    let isMagic = true;
    for(let j = 0; j < multiArray.length; j++) {
        magicSum += multiArray[0][j];
    }
    for(let i = 0; i < multiArray.length; i++) {
        for(let j = 0; j < multiArray.length; j++) {
            currentSum += multiArray[i][j];
        }
        if(currentSum !== magicSum) isMagic = false;
        currentSum = 0;
    }
    console.log(isMagic);
}
solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );