function solve(area, vol, input) {
    let parsedInputs = JSON.parse(input);
    let result = [];
    parsedInputs.forEach(parsedInput => {
        let areaObj = area.call(parsedInput);
        let volumeObj = vol.call(parsedInput);
        result.push({
            area: areaObj,
            volume:volumeObj
        });
    });
    return result;
}
function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};

console.log(solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]'));
solve(area, vol, '[{"x":"1","y":"2","z":"10"},{"x":"7","y":"7","z":"10"},{"x":"5","y":"2","z":"10"}]');