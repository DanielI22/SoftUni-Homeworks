function solve(input) {
    let table = [];

    for(let i = 1; i < input.length; i++) {
        let line = input[i].split("|");

        let name = line[1].trim();
        let lat = (+line[2].trim()).toFixed(2);
        let long = (+line[3].trim()).toFixed(2);

        let currentCity = {
            "Town": name,
            "Latitude" : +lat,
            "Longitude": +long
        }

        table.push(currentCity);
    }

    console.log(JSON.stringify(table));
}

solve(['| Town | Latitude | Longitude |',
'| Sofia | 42.696552 | 23.32601 |',
'| Beijing | 39.913818 | 116.363625 |']
)