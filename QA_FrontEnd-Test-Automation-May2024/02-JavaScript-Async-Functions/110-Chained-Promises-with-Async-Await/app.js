async function chainedPromisesAsync() {
    let promise1 = new Promise((res, rej) => {
        setTimeout(() => {
            res("promise 1 resolved");
        }, 1000);
    });

    let promise2 = new Promise((res, rej) => {
        setTimeout(() => {
            res("promise 2 resolved");
        }, 2000);
    });

    let promise3 = new Promise((res, rej) => {
        setTimeout(() => {
            res("promise 3 resolved");
        }, 3000);
    });

    let result1 = await promise1;
    let result2 = await promise2;
    let result3 = await promise3;

    console.log(`Result1: ${result1} / Result2: ${result2} / Result3: ${result3}`);
}