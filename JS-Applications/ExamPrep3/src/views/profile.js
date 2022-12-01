import { getUserMemes } from "../api/data.js";
import { html } from "../lib.js";

const profileTemplate = (user, userMemes) => html`        
        <section id="user-profile-page" class="user-profile">
            <article class="user-info">
                <img id="user-avatar-url" alt="user-profile"
                     src="${user.gender === 'female' ? '/images/female.png' : '/images/male.png'}">
                <div class="user-content">
                    <p>Username: ${user.username}</p>
                    <p>Email: ${user.email}</p>
                    <p>My memes count: ${userMemes.length}</p>
                </div>
            </article>
            <h1 id="user-listings-title">User Memes</h1>
            <div class="user-meme-listings">
                ${userMemes.length !== 0
                        ? userMemes.map(memeCardTemplate)
                        : html`<p class="no-memes">No memes in database.</p>`}
            </div>
        </section>`

const memeCardTemplate = (meme) => html`
           <div class="user-meme">
        <p class="user-meme-title">${meme.title}</p>
        <img class="userProfileImage" alt="meme-img" src="${meme.imageUrl}">
        <a class="button" href="/memes/${meme._id}">Details</a>
    </div>`

export async function showProfile(ctx) {
    const user = ctx.user;
    const userMemes = await getUserMemes(user._id);
    ctx.render(profileTemplate(user, userMemes));
}