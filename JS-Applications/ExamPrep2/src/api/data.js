import { del, get, post, put } from "./api.js";

export async function getAll() {
    return get('/data/games?sortBy=_createdOn%20desc');
}

export async function getLatest() {
    return get('/data/games?sortBy=_createdOn%20desc&distinct=category');
}

export async function getById(id) {
    return get(`/data/games/` + id);
}

export async function deleteById(id) {
    return del(`/data/games/` + id);
}

export async function createGame(data) {
    return post("/data/games", data);
}

export async function editGame(id, data) {
    return put("/data/games/" + id, data);
}