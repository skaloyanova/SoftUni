function promiseRejection() {
    let promise = new Promise((resolve, reject) => {
        setTimeout(() => {
            reject("Something went wrong!");
        }, 1000);
    });

    promise.catch((error) => {
        console.log(error);
    });
}