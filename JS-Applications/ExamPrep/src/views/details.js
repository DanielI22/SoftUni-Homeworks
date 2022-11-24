import { applyForOffer, getApplicationsByOfferId, getApplicationsByOfferIdforUser } from "../api/application.js";
import { deleteById, getAll, getById } from "../api/data.js";
import { html, nothing, page } from "../lib.js";

const detailsTemplate = (offer, hasUser, isOwner, onDelete, applications, onApply, hasApplied) => html`
<section id="details">
    <div id="details-wrapper">
        <img id="details-img" src="${offer.imageUrl}" alt="example1" />
        <p id="details-title">${offer.title}</p>
        <p id="details-category">
            Category: <span id="categories">${offer.category}</span>
        </p>
        <p id="details-salary">
            Salary: <span id="salary-number">${offer.salary}</span>
        </p>
        <div id="info-wrapper">
            <div id="details-description">
                <h4>Description</h4>
                <span>${offer.description}</span>
            </div>
            <div id="details-requirements">
                <h4>Requirements</h4>
                <span>${offer.requirements}</span>
            </div>
        </div>
        <p>Applications: <strong id="applications">${applications}</strong></p>

        <!--Edit and Delete are only for creator-->
        ${offerControls(offer, hasUser, isOwner, hasApplied, onDelete, onApply)}
    </div>
</section>`

function offerControls(offer, hasUser, isOwner, hasApplied, onDelete, onApply) {
    if(!hasUser) {
        return nothing;
    }

    if(isOwner) {
        return html`<div id="action-buttons">
        <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
        <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a></div>`
    }

    if(!hasApplied) {
        return html`<div id="action-buttons">
        <a @click=${onApply} href="javascript:void(0)" id="apply-btn">Apply</a></div>>`
    }
}

export async function showDetails(ctx) {
    const id = ctx.params.id;
    const offer = await getById(id);

    const hasUser = ctx.user;
    const isOwner = hasUser && ctx.user._id == offer._ownerId;

    const applications = await getApplicationsByOfferId(id);
    const hasApplied = await getApplicationsByOfferIdforUser(id, ctx.user._id);
    ctx.render(detailsTemplate(offer, hasUser, isOwner, onDelete, applications, onApply, hasApplied));

    async function onDelete() {
        const choice = confirm("Are you sure?");
        if(choice) {
            await deleteById(offer._id);
            ctx.page.redirect("/offers");
        }
    }

    async function onApply() {
        await applyForOffer(id);
        ctx.page.redirect("/offers/" + id);
    }
}

