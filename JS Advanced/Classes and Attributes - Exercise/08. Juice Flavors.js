function solve(input) {
    const bottles = new Map();
   
    input.reduce((acc, curr) => {
      let [juice, quantity] = curr.split(" => ");
      quantity = Number(quantity);
   
      if(!acc.hasOwnProperty(juice)) {
          acc[juice] = 0;
      }  
      acc[juice] += quantity;
   
      if (acc[juice] >= 1000) {
        if (!bottles.has(juice)) {
          bottles.set(juice, 0);
        }
   
      bottles.set(juice, bottles.get(juice) + parseInt(acc[juice] / 1000));
        acc[juice] %= 1000;
      }
   
      return acc;
    }, {});
   
   
    for(let[juice, quantity] of bottles) {
        console.log(`${juice} => ${quantity}`);
    }
}

solve(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']
);