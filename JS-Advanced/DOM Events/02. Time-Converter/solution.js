function attachEventsListeners() {

    let dayButton = document.getElementById('daysBtn');
    let hourButton = document.getElementById('hoursBtn');
    let minButton = document.getElementById('minutesBtn');
    let secButton = document.getElementById('secondsBtn');

    dayButton.addEventListener('click', () => {
        let days = document.getElementById('days').value;
        let hours = days*24;
        let minutes = days*1440;
        let seconds = days*86400;

        document.getElementById('hours').value = hours;
        document.getElementById('minutes').value = minutes;
        document.getElementById('seconds').value = seconds;
    });

    hourButton.addEventListener('click', () => {
        let hours = document.getElementById('hours').value;
        let days = hours/24;
        let minutes = days*1440;
        let seconds = days*86400;

        document.getElementById('days').value = days;
        document.getElementById('minutes').value = minutes;
        document.getElementById('seconds').value = seconds;
    });

    
    minButton.addEventListener('click', () => {
        let minutes = document.getElementById('minutes').value;
        let days = minutes/1440;
        let hours = days*24;
        let seconds = days*86400;

        document.getElementById('hours').value = hours;
        document.getElementById('days').value = days;
        document.getElementById('seconds').value = seconds;
    });

    secButton.addEventListener('click', () => {
        let seconds = document.getElementById('seconds').value;
        let days = seconds/86400;
        let hours = days*24;
        let minutes = days*1440;

        document.getElementById('hours').value = hours;
        document.getElementById('minutes').value = minutes;
        document.getElementById('days').value = days;
    });
}