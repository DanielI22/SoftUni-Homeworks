function lockedProfile() {
    let btn = Array.from(document.getElementsByTagName('button'));

    for(let button of btn) {
        button.addEventListener('click' , show);
    }

    function show(event) {
        let button = event.target;
        let info = button.parentElement.getElementsByTagName('div')[0];
        let check = button.parentElement.getElementsByTagName('input')[0].checked;
        if(!check) {
            if(button.textContent == "Show more") {
                info.setAttribute('style', 'display:block');
                button.textContent = "Hide it";
            }
            else {
                info.setAttribute('style', 'display:none');
                button.textContent = "Show more";
            }
        }
    }
}