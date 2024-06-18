function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      const input = document.querySelector('#inputs textarea');
      const outputBestRestaurant = document.getElementById('bestRestaurant').querySelector('p');
      const outputWorkers = document.getElementById('workers').querySelector('p');

      //Example input: ["Mikes - Steve 1000, Ivan 200, Paul 800", "Fleet - Maria 850, Janet 650"]
      const jsonInput = JSON.parse(input.value);   //convert to array of strings

      let restaurants = {};
      let bestRestaurantAverageSalary = 0;
      let bestRestaurantName;

      for (const entry of jsonInput) {    //example: Mikes - Steve 1000, Ivan 200, Paul 800
         const [restaurant, workersDetails] = entry.split(" - "); //restaurant = Mikes ; workersDetails = Steve 1000, Ivan 200, Paul 800;

         if (!restaurants.hasOwnProperty(restaurant)) {
            restaurants[restaurant] = [];
         }

         for (const worker of workersDetails.split(', ')) {    //["Steve 1000", "Ivan 200", "Paul 800"]
            const [name, salary] = worker.split(' ');          //name = Steve; salary = 1000

            const workerObj = {
               'name': name,
               'salary': parseInt(salary)
            }

            restaurants[restaurant].push(workerObj);
         }
      }

      // Calculate average salary for each restaurant and add it to the restaurants object
      Object.keys(restaurants).forEach(restaurant => {
         const workers = restaurants[restaurant];
         const totalSalary = workers.reduce((sum, worker) => sum + worker.salary, 0);
         const averageSalary = totalSalary / workers.length;

         if (averageSalary > bestRestaurantAverageSalary) {
            bestRestaurantName = restaurant;
            bestRestaurantAverageSalary = averageSalary;
         }

      });

      const sortedBestRestaurantWorkers = restaurants[bestRestaurantName].sort((a, b) => b.salary - a.salary);

      outputBestRestaurant.textContent = `Name: ${bestRestaurantName} Average Salary: ${bestRestaurantAverageSalary.toFixed(2)} Best Salary: ${sortedBestRestaurantWorkers[0].salary.toFixed(2)}`;

      let text = '';
      sortedBestRestaurantWorkers.forEach(w => text += `Name: ${w.name} With Salary: ${w.salary} `);

      outputWorkers.textContent = text;
   }
}