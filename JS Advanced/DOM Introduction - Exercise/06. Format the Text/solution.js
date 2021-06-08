function solve() {
  let input = document.getElementById("input").value;
  let sentences = input.split(".").filter(x=>x!=="").map(x =>x+".");
  let output = document.getElementById("output");
  let roof = Math.ceil(sentences.length/3);
  console.log(roof);

  for (let i = 0; i < roof; i++) {
    output.innerHTML+=`<p>${sentences.splice(0,3).join("")}</p>`;
  }
}