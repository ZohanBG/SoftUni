class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this._comments = [];
        this._likes = [];
    }

    get likes() {
        if (this._likes.length == 0) {
            return `${this.title} has 0 likes`;
        } else if (this._likes.length == 1) {
            return `${this._likes[0]} likes this story!`;
        } else {
            return $`${this._likes[0]} and ${this._likes.length - 1} others like this story!`;
        }

    }

    like(username){
        if(this._likes.includes(username)){
            throw new Error("You can't like the same story twice!");
        } else if(username == this.creator){
            throw new Error("You can't like your own story!");
        } else {
            this._likes.push(username)
            return `${username} liked ${this.title}!`;
        }
    }

    dislike (username){
        if(!this._likes.includes(username)){
            throw new Error("You can't dislike this story!");
        } else {
            let index = this._likes.indexOf(username);
            this._likes.splice(index, 1);
            return `${username} disliked ${this.title}`
        }
    }

    comment (username, content, id){
        if(id == undefined || !this._comments.some(x => x["id"] == id)){
            

        }
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);

