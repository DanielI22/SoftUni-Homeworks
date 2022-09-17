function solve(array) {
    array.sort((a,b) => a.localeCompare(b));
    let i = 1;
    array.forEach(element => {
        console.log(`${i}.${element}`);
        i++;
    });
}

solve(["John", "John", "Christina", "Ema"]);