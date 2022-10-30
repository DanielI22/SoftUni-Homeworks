async function getInfo() {
    let id = document.getElementById('stopId').value;
    let nameBox = document.getElementById('stopName');
    let listBox = document.getElementById('buses');
    try {
        nameBox.innerHTML = "";
        listBox.innerHTML = "";
        const response = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${id}`);

        const data = await response.json();
        nameBox.textContent = data.name;
        Object.entries(data.buses).forEach(([bus, time]) => {
			const e = document.createElement('li')
			e.innerHTML = `Bus ${bus} arrives in ${time}`

			listBox.appendChild(e)
		})
    } catch(err) {
        nameBox.textContent = 'Error';
    }
}