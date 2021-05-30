function solve(pies, startingPie, endingPie) {
    let startingIndex = pies.indexOf(startingPie);
    let endingIndex = pies.indexOf(endingPie);
    let result = pies.slice(startingIndex, endingIndex+1);
    return result
}