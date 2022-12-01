import { addComment, getCommentsGame } from "../api/comments.js";
import { deleteById, getAll, getById } from "../api/data.js";
import { html, nothing, page } from "../lib.js";
import { createSubmitHandler } from "../util.js";

const detailsTemplate = (game, hasUser, isOwner, onDelete, comments, onComment) => html`
        <section id="game-details">
            <h1>Game Details</h1>
            <div class="info-section">
        
                <div class="game-header">
                    <img class="game-img" src="${game.imageUrl}" />
                    <h1>${game.title}</h1>
                    <span class="levels">MaxLevel: ${game.maxLevel}</span>
                    <p class="type">${game.category}</p>
                </div>
        
                <p class="text">
                    ${game.summary}
                </p>
        
                <!-- Bonus ( for Guests and Users ) -->
                <div class="details-comments">
                    <h2>Comments:</h2>
                    <ul>
                        ${comments.length == 0 ? html` <p class="no-comment">No comments.</p>` :
                        comments.map(commentCardTemplate)}
                    </ul>
                </div>
        
                <!-- Edit/Delete buttons ( Only for creator of this game )  -->
                ${isOwner ? html` <div class="buttons">
                    <a href="/edit/${game._id}" class="button">Edit</a>
                    <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
                </div>` : nothing}
        
            </div>
        
            <!-- Bonus -->
            <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
            ${hasUser && !isOwner ? html`<article class="create-comment">
                <label>Add new comment:</label>
                <form @submit=${onComment} class="form">
                    <textarea name="comment" placeholder="Comment......"></textarea>
                    <input class="btn submit" type="submit" value="Add Comment">
                </form>
            </article>` : nothing}
        </section>`

const commentCardTemplate = (comments) => html`
        <li class="comment">
            <p>${comments.comment}</p>
        </li>`

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const game = await getById(id);

    const hasUser = ctx.user;
    const isOwner = hasUser && ctx.user._id == game._ownerId;

    const comments = await getCommentsGame(id);

    ctx.render(detailsTemplate(game, hasUser, isOwner, onDelete, comments, createSubmitHandler(onComment)));

    async function onDelete() {
        const choice = confirm("Are you sure?");
        if (choice) {
            await deleteById(game._id);
            ctx.page.redirect("/");
        }
    }

    async function onComment(comment) {
        if(!comment.comment) {
            return alert('Non empty please');
        }
        await addComment(id, comment.comment);
        document.getElementsByClassName("form")[0].reset();
        ctx.page.redirect("/games/" + id);
    }
}