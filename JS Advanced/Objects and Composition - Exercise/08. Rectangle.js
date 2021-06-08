function rectangle(a, b , c) {
    c = c[0].toUpperCase() + c.substring(1)
    return {
        width: a,
        height: b,
        color: c,
        calcArea: () =>{
            return a*b;
        }
    }
}
let rect = rectangle(4, 5, "red");
console.log(rect.width);
console.log(rect.height);
console.log(rect.color);
console.log(rect.calcArea());
