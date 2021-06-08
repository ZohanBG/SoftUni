function colorize() {
    let rows = document.querySelectorAll('table tr');
    for (let i = 0; i < rows.length; i++) {
        if(i % 2 == 1){
            rows[i].style.background = 'teal';
        }
    }
}