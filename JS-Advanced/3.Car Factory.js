function solve(input) {
    let smallEngine = { power: 90, volume: 1800 };
    let normalEngine = { power: 120, volume: 2400 };
    let monsterEngine  = { power: 200, volume: 3500 };

    let car = {};

    car['model'] = input.model;
    if(input.power <= 90) {
        car['engine'] = smallEngine;
    }
    else if (input.power <= 120) {
        car['engine'] = normalEngine;
    }
    else {
        car['engine'] = monsterEngine;
    }
    let carriage = {
        'type': input.carriage,
        'color': input.color
    }
    car['carriage'] = carriage;

    let carwheelsize = input.wheelsize;
    if(input.wheelsize % 2 == 0) {
        carwheelsize = input.wheelsize - 1;
    }
    let wheels = [carwheelsize,carwheelsize,carwheelsize,carwheelsize];
    car['wheels'] =  wheels;

    return car;

}
solve({ model: 'VW Golf II',
power: 90,
color: 'blue',
carriage: 'hatchback',
wheelsize: 14 }
);