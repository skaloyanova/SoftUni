/* VARIANT 1 */

async function startAdventure() {
    alert("Welcome to the simple text adventure game!");

    let command = "start";

    while (true) {
        let scenario = scenarios.find(s => s.command === command);

        let message = `${scenario.message} \n\n ${scenario.question}`;

        let userInput = await getUserInput(message);

        if (userInput === null) {
            alert("Thank you for playing!");
            return;
        }

        if (!scenario.options.includes(userInput)) {
            alert("Invalid option! Try again");
            continue;
        }

        await delay(500);

        command = userInput;

        if (command === "yes") {
            command = "start"
        }
        if (command === "no") {
            alert("Thank you for playing!");
            return;
        }
    }
}

async function getUserInput(message) {
    return new Promise(resolve => {
        const input = prompt(message);
        resolve(input);
    })
}

async function delay(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

const scenarios = [
    {
        command: "start",
        message: "You find yourself in a dark forest. You can go 'left' or 'right'.",
        question: "What do you do? (left/right): ",
        options: ["left", "right"]
    },
    {
        command: "left",
        message: "You encounter a wild animal! You can 'fight' or 'run'.",
        question: "What do you do? (fight/run): ",
        options: ["fight", "run"]
    },
    {
        command: "fight",
        message: "You bravely fight the animal and win!",
        question: "Do you want to play again? (yes/no): ",
        options: ["yes", "no"]
    },
    {
        command: "run",
        message: "You run away safely.",
        question: "Do you want to play again? (yes/no): ",
        options: ["yes", "no"]
    },
    {
        command: "right",
        message: "You find a treasure chest! You can 'open' it or 'leave' it.",
        question: "What do you do? (open/leave): ",
        options: ["open", "leave"]
    },
    {
        command: "open",
        message: "You open the chest and find a treasure! You win!",
        question: "Do you want to play again? (yes/no): ",
        options: ["yes", "no"]
    },
    {
        command: "leave",
        message: "You leave the chest and go back to the start.",
        question: "Do you want to play again? (yes/no): ",
        options: ["yes", "no"]
    }
]


/* VARIANT 2*/

// async function startAdventure() {
//     alert("Welcome to the simple text adventure game!");

//     let message;
//     let userInput;
//     let command = "start";

//     while (true) {

//         switch (command) {
//             case "start":
//                 message = "You find yourself in a dark forest. You can go 'left' or 'right'. \n\n What do you do? (left/right): ";

//                 userInput = await getUserInput(message);
//                 await delay(1000);

//                 switch (userInput) {
//                     case null:
//                         alert("Thank you for playing!");
//                         return;
//                     case "left":
//                         command = "left";
//                         break;
//                     case "right":
//                         command = "right";
//                         break;
//                     default:
//                         alert("Invalid option! Try again");
//                         break;
//                 }
//                 break;

//             case "left":
//                 message = "You encounter a wild animal! You can 'fight' or 'run'. \n\n What do you do? (fight/run): ";

//                 userInput = await getUserInput(message);
//                 await delay(1000);

//                 switch (userInput) {
//                     case null:
//                         alert("Thank you for playing!");
//                         return;
//                     case "fight":
//                         alert("You bravely fight the animal and win!");
//                         command = "end";
//                         break;
//                     case "run":
//                         alert("You run away safely.");
//                         command = "end";
//                         break;
//                     default:
//                         alert("Invalid option! Try again");
//                         break;
//                 }
//                 break;

//             case "right":
//                 message = "You find a treasure chest! You can 'open' it or 'leave' it. \n\n What do you do? (open/leave): ";

//                 userInput = await getUserInput(message);
//                 await delay(1000);

//                 switch (userInput) {
//                     case null:
//                         alert("Thank you for playing!");
//                         return;
//                     case "open":
//                         alert("You open the chest and find a treasure! You win!");
//                         command = "end";
//                         break;
//                     case "leave":
//                         alert("You leave the chest and go back to the start.");
//                         command = "end";
//                         break;
//                     default:
//                         alert("Invalid option! Try again");
//                         break;
//                 }
//                 break;

//             case "end":
//                 message = "Do you want to play again? (yes/no): ";

//                 userInput = await getUserInput(message);
//                 await delay(1000);

//                 switch (userInput) {
//                     case null:
//                         alert("Thank you for playing!");
//                         return;
//                     case "yes":
//                         command = "start";
//                         break;
//                     case "no":
//                         alert("Thank you for playing!");
//                         return;
//                     default:
//                         alert("Invalid option! Try again");
//                         break;
//                 }
//                 break;
//         }
//     }
// }

// async function getUserInput(message) {
//     return new Promise(resolve => {
//         const input = prompt(message);
//         resolve(input);
//     })
// }

// async function delay(ms) {
//     return new Promise(resolve => setTimeout(resolve, ms));
// }