function simplePromise() {
    let promise = new Promise((resolve) => {
        setTimeout(() => {
            resolve("Success!");
        }, 2000);
    })
    promise.then((resullt) => console.log(resullt));
}