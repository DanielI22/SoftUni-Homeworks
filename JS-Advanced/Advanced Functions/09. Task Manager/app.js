function solve() {
    let sections = document.getElementsByTagName('section');
    let addButton = document.getElementById('add');
    let startButton;
    let deleteButton;
    let finishButton;

    addButton.addEventListener('click', (event) => {
        event.preventDefault();
        let contentLocation = sections[1].children[1];
        let form = document.getElementsByTagName('form')[0];

        if(form.querySelectorAll('input')[0].value == '' 
        || form.querySelectorAll('textarea')[0].value == ''
        || form.querySelectorAll('input')[1].value == '')  {
            return;
        }

        let article = document.createElement('article');
        article.innerHTML = 
        `<h3>${form.querySelectorAll('input')[0].value}</h3>
        <p>Description: ${form.querySelectorAll('textarea')[0].value}</p>
        <p>Due Date: ${form.querySelectorAll('input')[1].value}</p>
        <div class = "flex">
            <button class = "green">Start</button>
            <button class = "red">Delete</button>
        </div>`

        form.querySelectorAll('input')[0].value = '';
        form.querySelectorAll('textarea')[0].value = '';
        form.querySelectorAll('input')[1].value = '';
        contentLocation.appendChild(article);

        startButton = article.querySelectorAll('button')[0];
        startButton.addEventListener('click', start);
        deleteButton = article.querySelectorAll('button')[1];
        deleteButton.addEventListener('click', deleted);
    })

   function start(event) {
        let article = event.target.parentElement.parentElement;
        let contentLocation = sections[2].children[1];
        let createdArticle = document.createElement('article');
        createdArticle.innerHTML = 
        `<h3>${article.querySelectorAll('h3')[0].textContent}</h3>
        <p>${article.querySelectorAll('p')[0].textContent}</p>
        <p>${article.querySelectorAll('p')[1].textContent}</p>
        <div class = "flex">
            <button class = "red">Delete</button>
            <button class = "orange">Finish</button>
        </div>`

        article.remove();
        contentLocation.appendChild(createdArticle);

        deleteButton = createdArticle.querySelectorAll('button')[0];
        deleteButton.addEventListener('click', deleted);
        finishButton = createdArticle.querySelectorAll('button')[1];
        finishButton.addEventListener('click', finish);
    }

    function deleted(event) {
        event.target.parentElement.parentElement.remove();
    }

    function finish(event) {
        let article = event.target.parentElement.parentElement;
        let contentLocation = sections[3].children[1];
        let createdArticle = document.createElement('article');
        createdArticle.innerHTML = 
        `<h3>${article.querySelectorAll('h3')[0].textContent}</h3>
        <p>${article.querySelectorAll('p')[0].textContent}</p>
        <p>${article.querySelectorAll('p')[1].textContent}</p>`

        article.remove();
        contentLocation.appendChild(createdArticle);
    }
}