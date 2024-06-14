function promiseWithMultipleHandlers() {
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Hello World");
        }, 2000);
    })
    promise
        .then((result) => {
            console.log(result);
            return result;
        })
        .then((result) => {
            console.log(result);
        });
}

let button = document.querySelector("button");
button.addEventListener('click', promiseWithMultipleHandlers);