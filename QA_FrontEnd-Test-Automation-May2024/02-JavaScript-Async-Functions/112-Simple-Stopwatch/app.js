let hours = 0;
let minutes = 0;
let seconds = 0;
let stopWatchInterval;
let saveTimeInterval;
let time = "";

const zeroPad = (num, places) => String(num).padStart(places, '0')

function startStopwatch() {
    console.log("Stopwatch started");
    stopWatchInterval = setInterval(() => {
        seconds++;

        if (seconds >= 60) {
            seconds = 0;
            minutes++;

            if (minutes >= 60) {
                minutes = 0;
                hours++;
            }
        }

        time = `${zeroPad(hours, 2)}:${zeroPad(minutes, 2)}:${zeroPad(seconds, 2)}`;
        console.log(time);

    }, 1000);

    saveTimeInterval = setInterval(async () => {
        await saveTime(time);
    }, 5000);
}

function stopStopwatch() {
    clearInterval(stopWatchInterval);
    clearInterval(saveTimeInterval);
    console.log("Stopwatch stopped");
    seconds = 0;
    minutes = 0;
    hours = 0;
}

function saveTime(time) {
    return new Promise((resolve, reject) => {
        console.log("Saved time: " + time);
        resolve();
    })
}