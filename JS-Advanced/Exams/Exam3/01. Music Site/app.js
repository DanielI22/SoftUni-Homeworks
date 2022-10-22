window.addEventListener('load', solve);

function solve() {
    let genre = document.getElementById('genre');
    let name = document.getElementById('name');
    let author = document.getElementById('author');
    let date = document.getElementById('date');

    let addButton = document.getElementById('add-btn');
    let collection = document.getElementsByClassName('all-hits-container')[0];
    let savedCont = document.getElementsByClassName('saved-container')[0];
    let totalLikes = 0;
    let totalLikesP = document.getElementsByClassName('likes')[0].children[0];
    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        let songGenre = genre.value;
        let songName = name.value;
        let songAuthor = author.value;
        let songDate = date.value;

        if(!songGenre || !songName || !songAuthor || !songDate) {
            return;
        }

        let song = document.createElement('div');
        song.classList.add('hits-info');
        song.innerHTML = `
        <img src = "./static/img/img.png">
        <h2>Genre: ${songGenre}</h2>
        <h2>Name: ${songName}</h2>
        <h2>Author: ${songAuthor}</h2>
        <h2>Date: ${songDate}</h2>
        <button class = "save-btn">Save song</button>
        <button class = "like-btn">Like song</button>
        <button class = "delete-btn">Delete</button>
        `
        collection.appendChild(song);

        song.querySelectorAll('button')[0].addEventListener('click', function (ev) { save(ev, songGenre, songName, songAuthor, songDate)});
        song.querySelectorAll('button')[1].addEventListener('click', function (ev) { like(ev)});
        song.querySelectorAll('button')[2].addEventListener('click', function (ev) { remove(ev)});

        genre.value = '';
        name.value = '';
        author.value = '';
        date.value = '';
    });

    function save(ev, songGenre, songName, songAuthor, songDate) {

        let saveSong = document.createElement('div');
        saveSong.classList.add('hits-info');
        saveSong.innerHTML = `
        <img src = "./static/img/img.png">
        <h2>Genre: ${songGenre}</h2>
        <h2>Name: ${songName}</h2>
        <h2>Author: ${songAuthor}</h2>
        <h2>Date: ${songDate}</h2>
        <button class = "delete-btn">Delete</button>`;

        savedCont.appendChild(saveSong);
        ev.target.parentElement.remove();
        saveSong.querySelectorAll('button')[0].addEventListener('click', function (ev) { remove(ev)});
    }

    function like(ev) {
        totalLikes++;
        totalLikesP.textContent = `Total Likes: ${totalLikes}`;
        ev.target.disabled = true;
    }

    function remove(ev) {
        ev.target.parentElement.remove();
    }
}