class Point{
    constructor(x, y){
        this.x = x;
        this.y = y;
    }

    static distance(pointA, pointB) {
        let a = pointB.x - pointA.x;
        let b = pointB.y - pointA.y;
        let c = Math.sqrt(a ** 2 + b ** 2);
        return c;
    }
}

let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));
