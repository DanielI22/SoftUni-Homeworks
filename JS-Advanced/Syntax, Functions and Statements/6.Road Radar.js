function solve(speed, area) {
    function zone(area) {
        if(area == 'motorway') {return 130;}
        else if(area=='interstate'){return 90;}
        else if(area=='city'){return 50;}
        else if(area=='residential'){return 20;}
    }

    let speedLimit = zone(area);
    let overSpeed = speed - speedLimit;
    let status;
    if(overSpeed  <= 0) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
        return;
    }
    else if(overSpeed <= 20) {
         status = 'speeding';
    }
    else if(overSpeed <= 40) {
         status = 'excessive speeding';
    }
    else {
         status = 'reckless driving';
    }
    console.log(`The speed is ${overSpeed} km/h faster than the allowed speed of ${speedLimit} - ${status}`)
}
solve(40, 'city');
solve(21, 'residential');