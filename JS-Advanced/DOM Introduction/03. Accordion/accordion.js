function toggle() {
    let textToToggle = document.getElementById("extra");
    let label = document.getElementsByClassName("button")[0];

    console.log(textToToggle);
    if(window.getComputedStyle(textToToggle, null).display == "none") {
        textToToggle.style.display = "block";
        label.textContent = "Less";
    }
    else {
        textToToggle.style.display = "none";
        label.textContent = "More";
    }
}