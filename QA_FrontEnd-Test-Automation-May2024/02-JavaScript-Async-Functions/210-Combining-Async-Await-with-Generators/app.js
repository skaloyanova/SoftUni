function asyncGenerator(generatorFunc) {
    const generator = generatorFunc();

    function handle(result) {
        if (result.done) {
            return Promise.resolve(result.value);
        }

        return Promise.resolve(result.value).then(
            res => handle(generator.next(res)),
            err => handle(generator.throw(err))
        )
    }

    try {
        return handle(generator.next())
    } catch (error) {
        return Promise.reject(error);
    }
}

function startAsyncGenerator() {
    asyncGenerator(generatorFunction);
}

const createTimeOutPromise = (id, timeout) => new Promise(resolve => {
    setTimeout(() => {
        resolve(`Task ${id} is completed.`)
    }, timeout);
});


function* generatorFunction() {
    const data1 = yield createTimeOutPromise(1, 1000);
    console.log(data1);
    const data2 = yield createTimeOutPromise(2, 500);
    console.log(data2);
    const data3 = yield createTimeOutPromise(3, 1500);
    console.log(data3);
    const data4 = yield createTimeOutPromise(4, 300);
    console.log(data4);
}