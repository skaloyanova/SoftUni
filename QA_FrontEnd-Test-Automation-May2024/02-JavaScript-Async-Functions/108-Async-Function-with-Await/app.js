async function simplePromiseAsync() {
    let result = await promise();
    console.log(result);
}

function promise() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("Async/Await is awesome!");
        }, 2000);
    })
}