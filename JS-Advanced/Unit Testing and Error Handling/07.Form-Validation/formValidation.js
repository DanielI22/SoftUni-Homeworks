function validate() {
    let username = document.getElementById('username');
    let email = document.getElementById('email');
    let pass = document.getElementById('password');
    let cpass = document.getElementById('confirm-password');
    let check = document.getElementById('company');
    let companyInfo = document.getElementById('companyInfo');
    let companyNum = document.getElementById('companyNumber');
    let submit = document.getElementById('submit');
    let validDiv = document.getElementById('valid');
    let isCompany;

    check.addEventListener('change', () => {
        if(check.checked) {
            companyInfo.style.display = 'block';
            isCompany = true;
        }
        else {
            companyInfo.style.display = 'none';
            isCompany = false;
        }
    })

    submit.addEventListener('click', (e) => {
        e.preventDefault();
        let allValid = true;
        
        if(!username.value.match(/^[a-zA-Z0-9]{3,20}$/g)) {
            username.style.borderColor = 'red';
            allValid = false;
        }
        else {
            username.style.border = 'none';
        }

        if(!pass.value.match(/^[\w]{5,15}$/g) || pass.value !== cpass.value) {
            pass.style.borderColor = 'red';
            cpass.style.borderColor = 'red';
            allValid = false;
        }
        else {
            pass.style.border = 'none';
            cpass.style.border = 'none';
        }

        if(!email.value.match(/^.*@.*\..*$/g)) {
            email.style.borderColor = 'red';
            allValid = false;
        }
        else {
            email.style.border = 'none';
        }
        if(isCompany) {
            if(companyNum.value < 1000 || companyNum.value > 9999) {
                companyNum.style.borderColor = 'red';
                allValid = false;
            }
            else {
                companyNum.style.border = 'none';
            }
        }

        if(allValid) {
            validDiv.style.display = 'block';
        }
        else {
            validDiv.style.display = 'none';
        }
    })

}
