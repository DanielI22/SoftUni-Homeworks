import { logout } from "../api/user.js";
import { html, render, page } from "../lib.js";
import { getUserData } from "../util.js";

const nav = document.querySelector('header');

const navTemplate = (hasUser) => html`
<a id="logo" href="/"><img id="logo-img" src="./images/logo.png" alt="" /></a>

<nav>
    <div>
        <a href="/albums">Dashboard</a>
    </div>

    ${hasUser ? html`<div class="user">
        <a href="/create">Add Album</a>
        <a href="javascript:void(0)" @click=${onLogout}>Logout</a>
    </div>` : html`    <div class="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
    </div>`}

</nav>
`

export function updateNav() {
    const user = getUserData();
    render(navTemplate(user), nav);
}

function onLogout() {
    logout();
    updateNav();
    page.redirect('/albums');
}