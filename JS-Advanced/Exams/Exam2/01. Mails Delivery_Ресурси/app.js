function solve() {
    let addButton = document.getElementById('add');
    let resetButton = document.getElementById('reset');

    let recipient = document.getElementById('recipientName');
    let title = document.getElementById('title');
    let message = document.getElementById('message');
    
    let list = document.getElementById('list');
    let sendMailsList = document.getElementsByClassName('sent-list')[0];
    let deleteMailsList = document.getElementsByClassName('delete-list')[0];
    resetButton.addEventListener('click', reset);
    addButton.addEventListener('click', add);

    function add(event) {
        event.preventDefault();
        if(!recipient.value || !title.value || !message.value) {
            return;
        }
        let mTitle = title.value;
        let mRec = recipient.value;
        let mMess = message.value;
        let element = document.createElement('li');
        element.innerHTML = `<h4>Title: ${mTitle}</h4>
        <h4>Recipient Name: ${mRec}</h4>
        <span>${mMess}</span>
        <div id="list-action">
            <button type="submit" id="send">Send</button>
            <button type="submit" id="delete">Delete</button>
        </div>`

        list.appendChild(element);
        element.querySelectorAll('#send')[0].addEventListener('click', function (ev) { sendE(ev, mTitle, mRec); });
        element.querySelectorAll('#delete')[0].addEventListener('click', function (ev) { deleteE(ev, mTitle, mRec); });
        reset(event);
    }

    function reset(event) {
        event.preventDefault();
        recipient.value = '';
        title.value = '';
        message.value = '';
    }

    function sendE(event, title, rec) {
        let mail = document.createElement('li');
        mail.innerHTML = `<span>To: ${rec}</span>
        <span>Title: ${title}</span>
        <div class="btn">
            <button type="submit" class="delete">Delete</button>
        </div>`
        sendMailsList.appendChild(mail);
        mail.querySelectorAll('.delete')[0].addEventListener('click', function (ev) { deleteE(ev, title, rec)});
        event.target.parentElement.parentElement.remove();
    }

    function deleteE(event, title, rec) {
        let mail = document.createElement('li');
        mail.innerHTML = `<span>To: ${rec}</span>
        <span>Title: ${title}</span>`
        deleteMailsList.appendChild(mail);

        event.target.parentElement.parentElement.remove();
    }
}
solve()