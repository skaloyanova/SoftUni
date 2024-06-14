
async function throttlePromises() {
    const createPromise = (id, delay) => () => new Promise((resolve) => {
        setTimeout(() => {
            console.log(`Task ${id} is completed`);
          resolve(`Task ${id} resolved`);
        }, delay);
      });
      
      const promises = [
        createPromise(1, 1000),
        createPromise(2, 500),
        createPromise(3, 300),
        createPromise(4, 400),
        createPromise(5, 200)
      ];

    async function throttle(promises, limit) {
        let activePromises = 0;
        let currentIndex = 0;
        let results = [];

        return new Promise((resolve, reject) => {
            function runNext() {
                if (currentIndex === promises.length && activePromises === 0) {
                    // All promises are resolved
                    resolve(results);
                    return;
                }

                while (activePromises < limit && currentIndex < promises.length) {
                    const promiseIndex = currentIndex;
                    const promise = promises[promiseIndex];

                    activePromises++;
                    currentIndex++;

                    promise()
                        .then(result => {
                            results.push(result);
                        })
                        .catch(error => {
                            results.push(error);
                        })
                        .finally(() => {
                            activePromises--;
                            runNext();
                        });
                }
            }

            runNext();
        });
    }

    const results = await throttle(promises, 2);
    console.log(`All tasks are done: \n${results}`);
}