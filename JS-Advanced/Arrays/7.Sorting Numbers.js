function solve(input) {
    let sort = input.sort((a, b) => a - b)
    let arr = []

    while (sort.length > 0) {
        arr.push(sort.shift(), sort.pop())
    }
   return arr;
}
solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56])