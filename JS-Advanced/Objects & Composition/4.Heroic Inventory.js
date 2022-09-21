function solve(input) {
    let heroes = [];
    for(hero of input) {
        let elements = hero.split(" / ");

        let items;
        if(elements.length == 2) {
            items = [];
        }
        else {
            items = elements[2].split(', ');
        }
        let currentHero = {
            "name": elements[0],
            "level": Number(elements[1]),
            "items": items
        }
        heroes.push(currentHero);
    }
    console.log(JSON.stringify(heroes));
}
solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
)