window.addEventListener("load", solve);

function solve() {
    let publish = document.getElementById('publish');
    let make = document.getElementById('make');
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let fuel = document.getElementById('fuel');
    let cost = document.getElementById('original-cost');
    let price = document.getElementById('selling-price');

    let tableBody = document.getElementById('table-body');
    let submitlist = document.getElementById('cars-list');
    let profit = 0;
    publish.addEventListener('click', (e) => {
      e.preventDefault();

      if(!make.value || !model.value ||!year.value || !fuel.value ||!cost.value ||!price.value ||price.value < cost.value) {
        return;
      }

      let post = document.createElement('tr');
      post.classList.add('row');
      post.innerHTML = 
      `<td>${make.value}</td>
      <td>${model.value}</td>
      <td>${year.value}</td>
      <td>${fuel.value}</td>
      <td>${cost.value}</td>
      <td>${price.value}</td>
      <td>
        <button class = "action-btn edit">Edit</button>
        <button class = "action-btn sell">Sell</button>
      </td>`

      tableBody.appendChild(post);
      post.querySelectorAll('button')[0].addEventListener('click', edit);
      post.querySelectorAll('button')[1].addEventListener('click', submit);

      make.value = '';
      model.value = '';
      year.value = '';
      fuel.value = '';
      cost.value = '';
      price.value = '';
    })

    function edit(event) {
      let currentrow = event.target.parentElement.parentElement;
      make.value = currentrow.children[0].textContent;
      model.value = currentrow.children[1].textContent;
      year.value = currentrow.children[2].textContent;
      fuel.value = currentrow.children[3].textContent;
      cost.value = currentrow.children[4].textContent;
      price.value = currentrow.children[5].textContent;
      currentrow.remove();

    }

    function submit(event) {
      let currentrow = event.target.parentElement.parentElement;
      let currentli = document.createElement('li');
      currentli.classList.add('each-list');
      currentli.innerHTML = 
      `
      <span>${currentrow.children[0].textContent + " " + currentrow.children[1].textContent}</span>
      <span>${currentrow.children[2].textContent}</span>
      <span>${+currentrow.children[5].textContent - +currentrow.children[4].textContent}</span>
      `

      submitlist.appendChild(currentli)
      currentrow.remove();

      profit+=+currentrow.children[5].textContent - +currentrow.children[4].textContent;

      document.getElementById("profit").textContent = profit.toFixed(2);
    }
} 
