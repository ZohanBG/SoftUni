function getArticleGenerator(articles) {
    let counter = 0;
    function inner () {
        if(counter<articles.length){
            let divElement = document.getElementById('content');
            let articleElement = document.createElement('article');
            articleElement.textContent = articles[counter];
            counter++;
            divElement.appendChild(articleElement);
        }
    }
    return inner;
}
