function getArticleGenerator(articles) {
    let currentArticle = articles.shift();
    let articlePlace = document.getElementById('content');
    console.log(currentArticle);
    return function() {
        if(currentArticle) {
            let a = articlePlace.appendChild(document.createElement("article"));
            a.textContent = currentArticle;
        }
        currentArticle = articles.shift();
    }
}
