async function retryPromise(promiseFunc, retries = 3) {
  let i = 1
  while(true) {
    try {
      const result = await promiseFunc();
      //console.log("try " + i++ + " " + result);
      return result;
    } catch (error) {
      //console.log("catch " + i++ + " " + error);
      retries--;

      if(retries === 0) {
        throw error;
      }
    }
  }
}

const unstablePromise = () => new Promise((resolve, reject) => {
  const random = Math.round(Math.random() * 10);
  random > 5 ? resolve(`Success!`) : reject(new Error(`Failed!`));
});

function startRetry(){
  retryPromise(unstablePromise)
  .then(result => console.log(`Result: ${result}`))
  .catch(error => console.log(`Error: ${error}`));
}