/* CHAINING FUNCTIONS */

// function chainedPromises() {
//     console.log("Start");
//     setTimeout(() => {
//         console.log(1);
//         setTimeout(() => {
//             console.log(2);
//             setTimeout(() => {
//                 console.log(3);
//             }, 1000);
//         }, 1000);
//     }, 1000);
// }

/* CHAINING PROMISES*/

function wait(timeout) {
    return new Promise(resolve => {
        setTimeout(() => {
            resolve();
        }, timeout);
    });
}

function chainedPromises() {
    console.log("Start");
    wait(1000)
        .then(() => {
            console.log(1);
            return wait(1000);
        })
        .then(() => {
            console.log(2);
            return wait(1000);
        })
        .then(() => {
            console.log(3);
        })
}