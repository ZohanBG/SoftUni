function solve() {
    let addButton = document.getElementById("add");
    addButton.addEventListener("click", function (e) {
        e.preventDefault();
        let taskText = document.getElementById("task").value;
        let descriptionText = document.getElementById("description").value;
        let dateText = document.getElementById("date").value;

        if(taskText == "" || descriptionText == "" || dateText == ""){
            return;
        }
        
        let openSectionElement = document.querySelectorAll("section")[1];
        let openSectionDiv = openSectionElement.querySelectorAll("div")[1];
        
        let articleElement = document.createElement("article");

        let h3Element = document.createElement("h3");
        h3Element.textContent = taskText;
        articleElement.appendChild(h3Element);

        let p1Element = document.createElement("p");
        p1Element.textContent = "Description: " + descriptionText;
        articleElement.appendChild(p1Element);

        let p2Element = document.createElement("p");
        p2Element.textContent = "Due Date: " + dateText;
        articleElement.appendChild(p2Element);

        let buttonsDiv = document.createElement("div");
        buttonsDiv.classList.add("flex");
        
        let startButton = document.createElement("button");
        startButton.textContent = "Start";
        startButton.classList.add("green");
        buttonsDiv.appendChild(startButton);

        let deleteButton = document.createElement("button");
        deleteButton.textContent = "Delete";
        deleteButton.classList.add("red");
        buttonsDiv.appendChild(deleteButton);

        articleElement.appendChild(buttonsDiv);

        deleteButton.addEventListener("click",function () {
            openSectionDiv.removeChild(articleElement);
        })

        startButton.addEventListener("click", function () {
            let inProgressSectionElement = document.querySelectorAll("section")[2];
            let inProgressDiv = inProgressSectionElement.querySelectorAll("div")[1];
            openSectionDiv.removeChild(articleElement);
            articleElement.removeChild(buttonsDiv);
            let buttonsDiv2 = document.createElement("div");
            buttonsDiv2.classList.add("flex");
            let deleteButton2 = document.createElement("button");
            deleteButton2.textContent = "Delete";
            deleteButton2.classList.add("red");
            buttonsDiv2.appendChild(deleteButton2);
            deleteButton2.addEventListener("click",function () {
                inProgressDiv.removeChild(articleElement);
            })
            let finishButton = document.createElement("button");
            finishButton.textContent = "Finish";
            finishButton.classList.add("orange");
            buttonsDiv2.appendChild(finishButton);

            finishButton.addEventListener("click",function () {
                let completeSectionElement = document.querySelectorAll("section")[3];
                let completeDiv = completeSectionElement.querySelectorAll("div")[1];
                articleElement.removeChild(buttonsDiv2);
                completeDiv.appendChild(articleElement);
            })

            articleElement.appendChild(buttonsDiv2);
            inProgressDiv.appendChild(articleElement);
        })
        openSectionDiv.appendChild(articleElement);
    })
}