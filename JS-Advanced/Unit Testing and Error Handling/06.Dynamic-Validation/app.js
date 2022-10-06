function validate() {
    let input = document.getElementById('email');
    input.addEventListener('change', () => {
        if(!input.value.match(/[a-zA-z]+@[a-zA-z]+.[a-zA-z]+/g)) {
            input.classList.add('error');
        }
        else {
            input.classList.remove('error');
        }
    })
}