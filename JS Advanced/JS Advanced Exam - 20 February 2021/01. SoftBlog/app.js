function solve(){
   let buttonElement = document.getElementsByClassName("btn create")[0];
   let archives = [];
   buttonElement.addEventListener("click", function (e) {
      e.preventDefault();
      let postElement = document.querySelectorAll("h2")[0].parentElement;

      let title = document.getElementById("title").value;
      let category = document.getElementById("category").value;
      let author = document.getElementById("creator").value;
      let content = document.getElementById("content").value;

      //Creating

      let articleElement = document.createElement("article");

      //Title

      let titleElement = document.createElement("h1");
      titleElement.textContent = title;
      articleElement.appendChild(titleElement);

      // Paragraph 1

      let p1 = document.createElement("p");
      p1.textContent = "Category:";
      let strong1 = document.createElement("strong");
      strong1.textContent = category;
      p1.appendChild(strong1);
      articleElement.appendChild(p1);

      // Paragraph 2 

      let p2 = document.createElement("p");
      p2.textContent = "Creator:";
      let strong2 = document.createElement("strong");
      strong2.textContent = author;
      p2.appendChild(strong2);
      articleElement.appendChild(p2);

      // Paragraph 3

      let p3 = document.createElement("p");
      p3.textContent = content;
      articleElement.appendChild(p3);

      // Button creation

      let buttonDiv = document.createElement("div");
      buttonDiv.classList.add("buttons");
      let deleteButtonElement = document.createElement("button");
      deleteButtonElement.textContent = "Delete";
      deleteButtonElement.classList.add("btn");
      deleteButtonElement.classList.add("delete");
      buttonDiv.appendChild(deleteButtonElement);
      articleElement.appendChild(buttonDiv);
      deleteButtonElement.addEventListener("click",function () {
         postElement.removeChild(articleElement);
      })

      let archiveButtonElement = document.createElement("button");
      archiveButtonElement.textContent = "Archive";
      archiveButtonElement.classList.add("btn");
      archiveButtonElement.classList.add("archive");
      buttonDiv.appendChild(archiveButtonElement);
      archiveButtonElement.addEventListener("click", function () {
         let olElement = document.querySelector("ol");
         olElement.innerHTML = '';
         archives.push(title);
         archives.sort((a,b)=> a.localeCompare(b));
         archives.forEach(element => {
            let li = document.createElement("li");
            li.textContent = element;
            olElement.appendChild(li);
         });
         postElement.removeChild(articleElement);
         
      })
      postElement.appendChild(articleElement);
   })
}
