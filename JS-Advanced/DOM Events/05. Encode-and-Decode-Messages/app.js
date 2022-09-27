function encodeAndDecodeMessages() {
    let button1 = document.getElementsByTagName('button')[0];
    let button2 = document.getElementsByTagName('button')[1];
    let messageArea = button1.parentElement.children[1];
    let resultArea = button2.parentElement.children[1];

    button1.addEventListener('click', () => {
        let result = '';
        for(let letter of messageArea.value) {
            result+=String.fromCharCode(letter.charCodeAt(0) + 1);
        }
        resultArea.value = result;
        messageArea.value = '';
    })

    button2.addEventListener('click', () => {
        let result = '';
        for(let letter of resultArea.value) {
            result+=String.fromCharCode(letter.charCodeAt(0) - 1);
        }
        resultArea.value = result;
    })
}