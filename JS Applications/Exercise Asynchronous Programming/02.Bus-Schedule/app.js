function solve() {

    let currentStation = 'depot';
    let infoDivElement = document.getElementById('info');
    let currentStopName = '';
    let departButtonElement = document.getElementById('depart');
    let arriveButtonElement = document.getElementById('arrive');

    function depart() {
        fetch(`http://localhost:3030/jsonstore/bus/schedule/${currentStation}`)
        .then(response => response.json())
        .then(data => {
            currentStation = data.next;
            currentStopName = data.name;
            infoDivElement.textContent = `Next stop ${currentStopName}`;
            departButtonElement.disabled = true;
            arriveButtonElement.disabled = false;
        })
        .catch(()=>{
            infoDivElement.textContent = 'Error';
            departButtonElement.disabled = true;
            arriveButtonElement.disabled = true;
        })
    }

    function arrive() {
        infoDivElement.textContent = `Arriving at ${currentStopName}`;
        departButtonElement.disabled = false;
        arriveButtonElement.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();