function solve(x1, y1, x2, y2) {
    let distance1 = Math.sqrt(x1*x1+y1*y1);
    let distance2 = Math.sqrt(x2*x2+y2*y2);
    let distance3 = Math.sqrt(Math.abs((x1-x2)*(x1-x2)+(Math.abs((y1-y2)*(y1-y2)))));
    let distance1Validity = Number.isInteger(distance1) ? 'valid' : 'invalid';
    let distance2Validity = Number.isInteger(distance2) ? 'valid' : 'invalid';
    let distance3Validity = Number.isInteger(distance3) ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {0, 0} is ${distance1Validity}`);
    console.log(`{${x2}, ${y2}} to {0, 0} is ${distance2Validity}`);
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${distance3Validity}`);
}

solve(2, 1, 1, 1)