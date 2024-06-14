function racePromise() {
    let promise1 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve promise 1");
            //reject("Reject promise 1");
        }, 1000);
    })

    let promise2 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve promise 2");
            //reject("Reject promise 2");
        }, 2000);
    })

    let promise3 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve promise 3");
        }, 3000);
    })

    Promise.race([promise1, promise2, promise3])
        .then((res) => console.log(res))
        .catch((err) => console.log("Error: " + err));
}

let button = document.querySelector("button");
button.addEventListener('click', racePromise);