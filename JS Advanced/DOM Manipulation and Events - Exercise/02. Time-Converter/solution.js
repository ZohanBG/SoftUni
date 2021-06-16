function attachEventsListeners() {
    let daysBtn = document.getElementById('daysBtn');
    let hoursBtn = document.getElementById('hoursBtn');
    let minutesBtn = document.getElementById('minutesBtn');
    let secondsBtn = document.getElementById('secondsBtn');

    let daysTextElement = document.getElementById('days');
    let hoursTextElement = document.getElementById('hours');
    let minutesTextElement = document.getElementById('minutes');
    let secondsTextElement = document.getElementById('seconds');

    daysBtn.addEventListener('click', function(){
        hoursTextElement.value = daysTextElement.value*24;
        minutesTextElement.value = daysTextElement.value*1440;
        secondsTextElement.value = daysTextElement.value*86400;
    });

    hoursBtn.addEventListener('click', function(){
        daysTextElement.value = hoursTextElement.value/24;
        minutesTextElement.value = hoursTextElement.value*60;
        secondsTextElement.value = hoursTextElement.value*3600;
    });

    minutesBtn.addEventListener('click', function(){
        daysTextElement.value = minutesTextElement.value/1440;
        hoursTextElement.value = minutesTextElement.value/60;
        secondsTextElement.value = minutesTextElement.value*60;
    });

    secondsBtn.addEventListener('click', function(){
        daysTextElement.value = secondsTextElement.value/86400;
        hoursTextElement.value = secondsTextElement.value/3600;
        minutesTextElement.value = secondsTextElement.value/60;
    });

}