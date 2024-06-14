function helloWorld() {
    console.log("Hello");
    setTimeout(() => {
        console.log("World");
    }, 2000);
}

// let button = document.getElementById("btn1");
// button.addEventListener('click', helloWorld);

function helloWorldWithPromise() {
    console.log("Hello");
    let promise = new Promise(resolve => {
        setTimeout(() => {
            resolve("World");
         }, 2000)
    });
    promise.then(result => console.log(result));
}

async function helloWorldWithAsyncFunction() {
    console.log("Hello");
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("World");
        }, 2000)
    });

    let result = await promise;
    console.log(result);
}