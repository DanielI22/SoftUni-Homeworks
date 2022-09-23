function subtract() {
    let a = (document.getElementById("firstNumber").value);
    let b = (document.getElementById("secondNumber").value);
    let c = a-b;
    document.getElementById("result").textContent=c;
}