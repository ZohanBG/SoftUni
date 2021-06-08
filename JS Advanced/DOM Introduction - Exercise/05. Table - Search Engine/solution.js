function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let searchField = document.getElementById("searchField").value;
      let rowElements = document.querySelectorAll("tbody tr");
      for (const row of rowElements) {
         row.className = "";
      }

      for (const row of rowElements) {
         let rowValues = Array.from(row.children);
         if(rowValues.some(el => el.textContent.includes(searchField))){
            row.className = "select";
         }
      }

      document.getElementById("searchField").value = '';
   }
}