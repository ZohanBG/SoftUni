function solution() {
    let buttonElement = document.querySelector("section div button");
    buttonElement.addEventListener("click", function (e){
        e.preventDefault();
        let giftText = document.querySelector("section div input").value;

        let giftLiElement = document.createElement("li");
        giftLiElement.textContent = giftText;
        giftLiElement.classList.add("gift");

        let sendButton = document.createElement("button");
        sendButton.textContent = "Send";
        sendButton.id = "sendButton";
        giftLiElement.appendChild(sendButton);

        sendButton.addEventListener("click", function () {
            sectionUl.removeChild(giftLiElement);
            let newLiElement = document.createElement("li");
            newLiElement.textContent = giftText;
            newLiElement.classList.add("gift");
            let sendSection = document.querySelectorAll("section")[2];
            let sendUl = sendSection.querySelector("ul");
            sendUl.appendChild(newLiElement);
        })

        let discardedButton = document.createElement("button");
        discardedButton.textContent = "Discard";
        discardedButton.id = "discardButton";
        giftLiElement.appendChild(discardedButton);

        discardedButton.addEventListener("click", function () {
            sectionUl.removeChild(giftLiElement);
            let newLiElement = document.createElement("li");
            newLiElement.textContent = giftText;
            newLiElement.classList.add("gift");
            let discardSection = document.querySelectorAll("section")[3];
            let discardedUl = discardSection.querySelector("ul");
            discardedUl .appendChild(newLiElement);
        })

       

        let sectionElement = document.querySelectorAll("section")[1];
        let sectionUl = sectionElement.querySelector("ul");


        sectionUl.appendChild(giftLiElement);

        Array.from(sectionUl.querySelectorAll("li"))
        .sort((a,b)=>a.textContent.localeCompare(b.textContent))
        .forEach(item=>sectionUl.appendChild(item));

        let giftText2 = document.querySelector("section div input");
        giftText2.value = null;
    });
}