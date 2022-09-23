function generateReport() {
    let report = [];
    let tableRows = document.querySelectorAll("table tr");
    for(let i = 1; i < tableRows.length; i++) {
        let currentRow = {};
        for(let j = 0; j < Math.floor(tableRows[i].childNodes.length/2); j++) {
            let currentCell = tableRows[i].childNodes[j*2 + 1];
            let currentColumnHeader = document.getElementsByTagName("th")[j]
            if(document.querySelectorAll("input")[j].checked) {
                currentRow[document.querySelectorAll("input")[j].name] = currentCell.textContent;
            }
        }

        report.push(currentRow);
    }

    document.getElementById("output").textContent = JSON.stringify(report, null, 2);
}