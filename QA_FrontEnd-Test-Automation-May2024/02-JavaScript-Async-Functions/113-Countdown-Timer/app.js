let countdownInterval;

async function getUserInput(promptMessage) {
    return new Promise((resolve) => {
        const input = prompt(promptMessage, "5");
        resolve(input);
    });
}

async function startCountdown(){
    const userInput = await getUserInput("Enter the number of seconds for the countdown:");
    let timeLeft = Number(userInput);
    
    if (isNaN(timeLeft) || timeLeft <= 0) {
        console.log("Please enter a valid number of seconds.");
        return;
    }

    countdownInterval = setInterval(async() => {
        console.log(`Time left: ${timeLeft} seconds`);
        timeLeft--;

        if (timeLeft < 0) {
            clearInterval(countdownInterval);
            await saveTime();
        }

    }, 1000);
}

function saveTime(){
    return new Promise((resolve, reject) => {
        console.log("Finished. Time saved");
        resolve();
    })
}