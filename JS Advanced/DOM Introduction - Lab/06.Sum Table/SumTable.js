function sumTable() {
    let prices = document.querySelectorAll('table tr');
    let sum = 0;
    for (let i = 1; i < prices.length; i++) {
        let row = prices[i].children;
        let cost = row[row.length-1].textContent;
        let number = Number(cost);
        sum += number
    }
    document.getElementById("sum").textContent = sum; 
}