function addItem() {
    let newItemText = document.getElementById("newItemText");
    let newItemValue = document.getElementById("newItemValue");

    let option = document.createElement('option');
    option.textContent = newItemText.value;
    option.value = newItemValue.value;
    document.getElementById("menu").appendChild(option);
    newItemText.value = '';
    newItemValue.value = '';
}