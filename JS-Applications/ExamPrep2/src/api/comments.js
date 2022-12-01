import { get, post } from "./api.js";

export async function getCommentsGame(gameId) {
    return get(`/data/comments?where=gameId%3D%22${gameId}%22`)
}

export async function addComment(gameId, comment) {
    return post('/data/comments', {gameId, comment});
}