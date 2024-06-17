function attachEventsListeners() {
    const daysInput = document.getElementById('days');
    const hoursInput = document.getElementById('hours');
    const minutesInput = document.getElementById('minutes');
    const secondsInput = document.getElementById('seconds');
    const buttons = document.querySelectorAll('input[type=button]');

    buttons.forEach(b => b.addEventListener('click', convertTime));

    const ratio = {
        days: 1,
        hours: 24,
        minutes: 1440,
        seconds: 86400
    }

    function convert(value, unit) {
        let convertedInDays = value / ratio[unit];
        return {
            days: convertedInDays,
            hours: convertedInDays * ratio.hours,
            minutes: convertedInDays * ratio.minutes,
            seconds: convertedInDays * ratio.seconds
        }
    }

    function convertTime(event) {
        let input = event.currentTarget.parentElement.querySelector('input[type=text]');

        const time = convert(input.value, input.id);

        daysInput.value = time.days;
        hoursInput.value = time.hours;
        minutesInput.value = time.minutes;
        secondsInput.value = time.seconds;
    }
}