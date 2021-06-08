function search() {
   let allElements = Array.from(document.querySelectorAll("#towns li"));
   let searchText = document.getElementById("searchText").value;
   allElements.forEach(el => {
      el.style.textDecoration = "none";
      el.style.fontWeight = "normal";
   });
   let selectedElements = allElements.filter(x=>x.textContent.includes(searchText));

   let mappedElements = selectedElements.map(el => {
      el.style.textDecoration = "underline";
      el.style.fontWeight = "bold";
   });
   
   document.getElementById("result").textContent = `${mappedElements.length} matches found`
}
