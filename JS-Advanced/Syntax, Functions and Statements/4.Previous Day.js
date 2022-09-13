function solve(year, month, day) {
    let previousDate = new Date(year, month - 1, day - 1);
    let newYear = previousDate.getFullYear();
    let newMonth = previousDate.getMonth() + 1;
    let newDate = previousDate.getDate();
    console.log(`${newYear}-${newMonth}-${newDate}`);
}
solve(2016, 10, 1);