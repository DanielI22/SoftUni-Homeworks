function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   function onClick() {
      let array = JSON.parse(document.querySelector("#inputs textarea").value);

      let restList = [];
      for (let line of array) {

         let [name, workers] = line.split(" - ");

         let exists = false;
         let currentRest;
         restList.forEach(restaurant => {
            if(restaurant.name === name) {
               exists = true;
               currentRest = restaurant;
            }
         })

         if(!exists) {
            let workerList = [];
            for (let worker of workers.split(', ')) {
               let [workerName, workerSalary] = worker.split(' ');
               workerSalary = +workerSalary;
               let currentWorker = {
                  workerName,
                  workerSalary
               }
               workerList.push(currentWorker);

            }
            let restaurant = {
               name,
               workerList
            }

            restList.push(restaurant)
         }
         else {
            for (let worker of workers.split(', ')) {
               let [workerName, workerSalary] = worker.split(' ');
               workerSalary = +workerSalary;
               let currentWorker = {
                  workerName,
                  workerSalary
               }
              currentRest.workerList.push(currentWorker);
            }
         }
      }

      let salariesList = [];
      for (let restaurant of restList) {
         let sumSalary = 0;
         restaurant.workerList.forEach(worker => {
            sumSalary += worker.workerSalary;
         });
         let averageSal = sumSalary / restaurant.workerList.length;
         salariesList.push(averageSal);
         restaurant['averSalary'] = averageSal;
      }

      let bestRest;
      for (let restaurant of restList) {
         if(restaurant.averSalary == Math.max(...salariesList)) {
            bestRest = restaurant;
         }
      }
      let bestSalary = 0;
      bestRest.workerList.forEach(worker => {
         if(worker.workerSalary > bestSalary) {
            bestSalary = worker.workerSalary;
         }
      })

      bestRest.workerList.sort((a,b) => b.workerSalary - a.workerSalary);

      let bestRestPlace = document.querySelector("#bestRestaurant p");
      let bestRestWorkers = document.querySelector("#workers p");
      bestRestPlace.textContent = `Name: ${bestRest.name} Average Salary: ${bestRest.averSalary.toFixed(2)} Best Salary: ${bestSalary.toFixed(2)}`;

      bestRest.workerList.forEach(worker => {
         bestRestWorkers.textContent += `Name: ${worker.workerName} With Salary: ${worker.workerSalary} `;
      })
   }
}