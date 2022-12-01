import { deleteById, getAll, getById } from "../api/data.js";
import { html, nothing, page } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const detailsTemplate = (meme, hasUser, isOwner, onDelete) => html`
                        <section id="meme-details">
                        <h1>Meme Title: ${meme.title}
                        </h1>
                        <div class="meme-details">
                            <div class="meme-img">
                                <img alt="meme-alt" src="${meme.imageUrl}">
                            </div>
                            <div class="meme-description">
                                <h2>Meme Description</h2>
                                <p>
                                    ${meme.description}
                                </p>
                                ${isOwner
                                        ? html`<a class="button warning" href="/edit/${meme._id}">Edit</a>
                                        <button class="button danger" @click=${onDelete}>Delete</button>`
                                        : nothing}
                            </div>
                        </div>
                    </section>`

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const meme = await getById(id);

    const hasUser = ctx.user;
    const isOwner = hasUser && ctx.user._id == meme._ownerId;


    ctx.render(detailsTemplate(meme, hasUser, isOwner, onDelete));

    async function onDelete() {
        const choice = confirm("Are you sure?");
        if (choice) {
            await deleteById(meme._id);
            ctx.page.redirect("/memes");
        }
    }
}