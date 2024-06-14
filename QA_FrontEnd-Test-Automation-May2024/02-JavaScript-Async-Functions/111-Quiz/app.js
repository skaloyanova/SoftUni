async function startQuiz() {
    let finalScore = 0;

    for (let i = 0; i < questions.length; i++) {
        const { question, answers, correct } = questions[i];

        let userInput = await askQuestion(question, answers);
        
        if (userInput === correct) {
            finalScore++;
            console.log("Correct");
        } else {
            console.log("Not correct");
        }
    };

    console.log("Final score: " + finalScore);
}

function askQuestion(question, answers) {
    return new Promise((resolve, reject) => {
        let message = question + "\n";
        for (const [key, value] of Object.entries(answers)) {
            message += `${key}) ${value} \n`
        }
          
        let userInput = prompt(message);
        resolve(userInput);
    })
}

const questions = [
    {
        question: "What is 2 + 2?",
        answers: {
            a: "3",
            b: "4",
            c: "5"
        },
        correct: "b"
    },
    {
        question: "What is the capital of France?",
        answers: {
            a: "Berlin",
            b: "Madrid",
            c: "Paris"
        },
        correct: "c"
    },
    {
        question: "What is the square root of 16?",
        answers: {
            a: "4",
            b: "5",
            c: "6"
        },
        correct: "a"
    }
]

// async function startQuiz() {
//     let finalScore = 0;

//     for (let i = 0; i < questions.length; i++) {
//         const { question, answers, correct } = questions[i];

//         let userInput = await askQuestion(question, answers);
        
//         if (userInput === correct) {
//             finalScore++;
//             console.log("Correct");
//         } else {
//             console.log("Not correct");
//         }
//     };

//     console.log("Final score: " + finalScore);
// }

// function askQuestion(question, answers) {
//     return new Promise((resolve, reject) => {
//         let message = question + "\n";
//         answers.forEach((answer, index) => message += `${index}) ${answer} \n`);
//         let userInput = prompt(message);
//         resolve(Number(userInput));
//     })
// }

// const questions = [
//     {
//         question: "What is 2 + 2?",
//         answers: ["3", "4", "5"],
//         correct: 1
//     },
//     {
//         question: "What is the capital of France?",
//         answers: ["Berlin", "Madrid", "Paris"],
//         correct: 2
//     },
//     {
//         question: "What is the square root of 16?",
//         answers: [4, 5, 6],
//         correct: 0
//     }
// ]