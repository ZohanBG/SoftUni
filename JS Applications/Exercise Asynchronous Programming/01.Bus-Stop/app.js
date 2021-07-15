function getInfo() {
    let busId = document.getElementById('stopId').value;
    let stopNameElement = document.getElementById('stopName');
    let ulElement = document.getElementById('buses');
    while (ulElement.firstChild) {
        ulElement.removeChild(ulElement.firstChild);
    }
    fetch(`http://localhost:3030/jsonstore/bus/businfo/${busId}`)
    .then(response => response.json())
    .then(data => {
        stopNameElement.textContent = data.name;
        for (const key in data.buses) {
            let liElement = document.createElement('li');
            liElement.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;
            ulElement.appendChild(liElement);
        }
    })
    .catch(() => {
        stopNameElement.textContent = 'Error';
    }); 
}