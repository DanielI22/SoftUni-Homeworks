import { login } from "../api/user.js";
import { html, nothing } from "../lib.js";
import { createSubmitHandler } from "../util.js";
import { showNotification } from "./notification.js";

const loginTemplate = (onLogin, errorMsg) => html`
        <section id="login">
            <form @submit=${onLogin} id="login-form">
                <div class="container">
                    <h1>Login</h1>
                    <label for="email">Email</label>
                    <input id="email" placeholder="Enter Email" name="email" type="text">
                    <label for="password">Password</label>
                    <input id="password" type="password" placeholder="Enter Password" name="password">
                    <input type="submit" class="registerbtn button" value="Login">
                    <div class="container signin">
                        <p>Dont have an account?<a href="/register">Sign up</a>.</p>
                    </div>
                </div>
            </form>
        </section>
        ${errorMsg ? showNotification(errorMsg) : nothing}`

export function showLogin(ctx) {
    ctx.render(loginTemplate(createSubmitHandler(onLogin)));

    async function onLogin({ email, password }) {
        if (!email || !password) {
            ctx.render(loginTemplate(createSubmitHandler(onLogin), "Error"));;
        }

        await login(email, password);
        ctx.updateNav();
        ctx.page.redirect('/memes');
    }
}