function allPromise() {
    let promise1 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve 1");
        }, 1000);
    })

    let promise2 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve 2");
            //reject("Reject 2");
        }, 2000);
    })

    let promise3 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Resolve 3");
            //reject("Reject 3");
        }, 3000);
    })

    Promise.all([promise1, promise2, promise3])
        .then((res) => console.log(res))
        .catch((res) => console.log("Error: " + res));
}

let button = document.querySelector("button");
button.addEventListener('click', allPromise);