function solve(text) {
    let words = text.match(/\w+/g)
    let upperWords = [];
    words.forEach(word => {
        upperWords.push(word.toUpperCase());           
    });
    console.log(upperWords.join(', '));
}

solve('hello, my name is evtim')