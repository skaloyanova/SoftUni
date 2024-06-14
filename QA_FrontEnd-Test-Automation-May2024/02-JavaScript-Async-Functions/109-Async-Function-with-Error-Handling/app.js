async function promiseRejectionAsync() {
   let promise = new Promise((resolve, reject) => {
      setTimeout(() => {
         reject(new Error("error appeared"));
      }, 1000);
   })

   try {
      let result = await promise;
   } catch(error) {
      console.log(error);
   }
}