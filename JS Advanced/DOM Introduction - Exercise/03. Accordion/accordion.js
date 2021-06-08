function toggle() {
    let text = document.getElementsByClassName("button")[0].textContent;
    let showText = document.getElementById("extra");
    if(text == "More"){
        document.getElementsByClassName("button")[0].textContent = "Less";
        showText.style.display = "block";

    } else {
        document.getElementsByClassName("button")[0].textContent = "More";
        showText.style.display = "none";
    }
}