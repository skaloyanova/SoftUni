function multiplePromises() {
      const promise1 = new Promise((resolve, reject) => {
            setTimeout(() => {
                  resolve("Promise 1 resolved");
            }, 1000);
      })

      const promise2 = new Promise((resolve, reject) => {
            setTimeout(() => {
                  resolve("Promise 2 resolved");
            }, 2000);
      })

      const promise3 = new Promise((resolve, reject) => {
            setTimeout(() => {
                  reject("Promise 3 rejected");
            }, 3000);
      })

      Promise.allSettled([promise1, promise2, promise3])
            .then(result => result.forEach(r => console.log(r.status, r.value || r.reason)));
}