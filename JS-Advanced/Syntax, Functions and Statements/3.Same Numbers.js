function solve(num) {
    let sum = 0;
    let digit = num%10;
    let flag = true;
    while(num > 0) 
    {
        let currentDig = num % 10;
        sum += currentDig;
        if(currentDig !== digit) {
            flag = false;
        }
        num = Math.floor(num /10);
    }
    console.log(flag);
    console.log(sum);

}
solve(15)