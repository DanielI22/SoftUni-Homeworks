import { getAll } from "../api/data.js";
import { html } from "../lib.js";

const gamesTemplate = (memes) => html`
<section id="meme-feed">
<h1>All Memes</h1>
<div id="memes">
    ${memes.length == 0 ? html `<p class="no-memes">No memes in database.</p>` : memes.map(memeCardTemplate)}
    </div>
</section>`

const memeCardTemplate = (meme) => html`
        <div class="meme">
        <div class="card">
            <div class="info">
                <p class="meme-title">${meme.title}</p>
                <img class="meme-image" alt="meme-img" src="${meme.imageUrl}">
            </div>
            <div id="data-buttons">
                <a class="button" href="/memes/${meme._id}">Details</a>
            </div>
        </div>
    </div>`


export async function shoeMemes(ctx) {
    const memes = await getAll();
    ctx.render(gamesTemplate(memes));
}