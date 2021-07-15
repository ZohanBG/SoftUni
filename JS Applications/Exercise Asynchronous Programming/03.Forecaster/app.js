function attachEvents() {
    document.getElementById('submit')
    .addEventListener('click',(e)=>{
        e.preventDefault();

        let weatherConditions = {
            'Sunny' : '☀',
            'Partly sunny' : '⛅',
            'Overcast' : '☁',
            'Rain' : '☂',
            'Degrees' : '°'
        }

        let forecastDivElement = document.getElementById('forecast');
        let currentDivElement = document.getElementById('current');
        Array.from(currentDivElement.querySelectorAll('div'))
        .forEach((el,i) => {
            if(i != 0){
                el.remove();
            }
        });
        let upcomingDivElement = document.getElementById('upcoming');
        Array.from(upcomingDivElement.querySelectorAll('div'))
        .forEach((el,i) => {
            if(i != 0){
                el.remove();
            }
        });
        let locationName = document.getElementById('location').value;
        let locationCode = '';

        fetch('http://localhost:3030/jsonstore/forecaster/locations')
        .then(response => response.json())
        .then(data => {
            let location = data.find(x=> x.name === locationName);
            locationCode = location.code;
            return fetch(`http://localhost:3030/jsonstore/forecaster/today/${locationCode}`);
        })
        .then(response => response.json())
        .then(data => {
            forecastDivElement.style.display = 'block';
            let divElement = document.createElement('div');
            divElement.classList.add('forecasts');
            let spanElement = document.createElement('span');
            spanElement.classList.add('condition', 'symbol');
            spanElement.textContent = weatherConditions[data.forecast.condition];
            divElement.appendChild(spanElement);

            let infoSpanElement = document.createElement('span');
            infoSpanElement.classList.add('condition');

            let townSpanElement = document.createElement('span');
            townSpanElement.classList.add('forecast-data');
            townSpanElement.textContent = data.name;
            infoSpanElement.appendChild(townSpanElement);

            let degreesSpanElement = document.createElement('span');
            degreesSpanElement.classList.add('forecast-data');
            degreesSpanElement.textContent =`${data.forecast.low}${weatherConditions.Degrees}/${data.forecast.high}${weatherConditions.Degrees}`;
            infoSpanElement.appendChild(degreesSpanElement);

            let weatherSpanElement = document.createElement('span');
            weatherSpanElement.classList.add('forecast-data');
            weatherSpanElement.textContent = data.forecast.condition;
            infoSpanElement.appendChild(weatherSpanElement);
            divElement.appendChild(infoSpanElement);
            
            currentDivElement.appendChild(divElement);

            return fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${locationCode}`);
        })
        .then(response => response.json())
        .then(data => {
            let divElement = document.createElement('div');
            divElement.classList.add('forecast-info');
            data.forecast.forEach(forecast => {
                let upcomingSpanElement = document.createElement('span');
                upcomingSpanElement.classList.add('upcoming');

                let symbolSpanElement = document.createElement('span');
                symbolSpanElement.classList.add('symbol');
                symbolSpanElement.textContent = weatherConditions[forecast.condition];
                upcomingSpanElement.appendChild(symbolSpanElement);

                let degreesSpanElement = document.createElement('span');
                degreesSpanElement.classList.add('forecast-data');
                degreesSpanElement.textContent =`${forecast.low}${weatherConditions.Degrees}/${forecast.high}${weatherConditions.Degrees}`;
                upcomingSpanElement.appendChild(degreesSpanElement);

                let weatherSpanElement = document.createElement('span');
                weatherSpanElement.classList.add('forecast-data');
                weatherSpanElement.textContent = forecast.condition;
                upcomingSpanElement.appendChild(weatherSpanElement);

                divElement.appendChild(upcomingSpanElement);

            });

            upcomingDivElement.appendChild(divElement);
        })
        .catch(()=>{ 
            forecastDivElement.textContent = 'Error';
            forecastDivElement.style.display = 'block';
        })
        

    })
}

attachEvents();