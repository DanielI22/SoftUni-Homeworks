import { register } from "../api/user.js";
import { html } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const registerTemplate = (onRegister) => html`
        <section id="register-page" class="content auth">
            <form @submit=${onRegister} id="register">
                <div class="container">
                    <div class="brand-logo"></div>
                    <h1>Register</h1>
        
                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="maria@email.com">
        
                    <label for="pass">Password:</label>
                    <input type="password" name="password" id="register-password">
        
                    <label for="con-pass">Confirm Password:</label>
                    <input type="password" name="confirm-password" id="confirm-password">
        
                    <input class="btn submit" type="submit" value="Register">
        
                    <p class="field">
                        <span>If you already have profile click <a href="/login">here</a></span>
                    </p>
                </div>
            </form>
        </section>`

export function showRegister(ctx) {
    ctx.render(registerTemplate(createSubmitHandler(onRegister)));

    async function onRegister(data) {
        const email = data.email;
        const password = data.password;
        const repPass = data['confirm-password'];
        if (!email || !password) {
            return alert("All fields are required");
        }

        if (password != repPass) {
            return alert("Passwords don't match");
        }

        await register(email, password);
        ctx.updateNav();
        ctx.page.redirect('/');
    }
}