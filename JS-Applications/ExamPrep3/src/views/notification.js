import { html, render } from "../lib.js";

const notifications = document.getElementById('notifications');

const notificationTemplate = (errorMessage) => html`
  <div id="errorBox" class="notification">
                <span>${errorMessage}</span>
            </div>`

export function showNotification(errorMessage) {
    render(notificationTemplate(errorMessage), notifications);
}