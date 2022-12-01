import { addComment } from './api/comments.js';
import { page, render } from './lib.js';
import { getUserData } from "./util.js";
import { showCreate } from './views/create.js';
import { showDetails } from './views/details.js';
import { showEdit } from './views/edit.js';
import { showGames } from './views/games.js';
import { showHome } from './views/home.js';
import { showLogin } from "./views/login.js";
import { updateNav } from "./views/nav.js";
import { showRegister } from './views/register.js';

const main = document.getElementById('main-content');

page(decorateContext);
page('/', showHome);
page('/login', showLogin);
page('/register', showRegister);
page('/games', showGames);
page('/create', showCreate);
page('/games/:id', showDetails);
page('/edit/:id',  showEdit);

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUserData();
    if(user) {
        ctx.user = user;
    }

    next();
}

function renderMain(content) {
    render(content, main);
}

window.com = addComment;