function attachEvents() {
    const sendBtn = document.getElementById('submit');
    const refreshBtn = document.getElementById('refresh');

    refreshBtn.addEventListener('click', displayMsgs);
    sendBtn.addEventListener('click', sendMsg);
}

async function getAllMsg() {
    const response = await fetch("http://localhost:3030/jsonstore/messenger");
    const data = await response.json();
    return data;
}


async function displayMsgs() {
    let data = await getAllMsg();
    const result = Object.values(data).map(element => 
        `${element.author}: ${element.content}`).join("\n");
    const output = document.getElementById("messages");
    output.textContent = result;
}

function getCurrentMsg() {
    const author = document.getElementsByName("author")[0].value;
    const content = document.getElementsByName("content")[0].value;

    return {
        author: author,
        content: content,
      };
}
async function sendMsg() {
    const message = getCurrentMsg();
    fetch("http://localhost:3030/jsonstore/messenger", 
    {
        method: "POST",
        headers: {
            "Content-type": "application.json"
        },
        body: JSON.stringify(message)
    })
}

attachEvents();