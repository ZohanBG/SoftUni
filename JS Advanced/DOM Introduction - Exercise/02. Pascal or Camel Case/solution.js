function solve() {
  let input = document.getElementById("text").value.toLowerCase();
  let namingConversion = document.getElementById("naming-convention").value;
  let array = input.split(" ");
  let result = ""
  if (namingConversion == "Camel Case") {
      result += array[0];
      for (let i = 1; i < array.length; i++) {
          result += array[i][0].toUpperCase() + array[i].substring(1);
      }
  } else if (namingConversion == "Pascal Case") {
      for (let i = 0; i < array.length; i++) {
          result += array[i][0].toUpperCase() + array[i].substring(1);
      }
  } else {
      result = "Error!";
  }
  document.getElementById("result").textContent = result;
}