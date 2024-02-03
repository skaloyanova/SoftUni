//Create a function, which creates a register for heroes, with their names, level, and items (if they have such)

function inventory(inputArray) {
    'use strict';

    //Input string => {heroName} / {heroLevel} / {item1}, {item2}, {item3}...

    let heroes = [];

    for (const input of inputArray) {
        const split = input.split(' / ');
        let [heroName, heroLevel, items] = split;

        heroes.push({
            hero: heroName,
            level: Number(heroLevel),
            items: items
        })
    }

    heroes
        .sort((a, b) => a.level - b.level)
        .forEach(h => console.log(`Hero: ${h.hero}\nlevel => ${h.level}\nitems => ${h.items}`));
}


//test data
inventory([
    'Isacc / 25 / Apple, GravityGun',
    'Derek / 12 / BarrelVest, DestructionSword',
    'Hes / 1 / Desolator, Sentinel, Antara'
]
);
console.log('');
inventory([
    'Batman / 2 / Banana, Gun',
    'Superman / 18 / Sword',
    'Poppy / 28 / Sentinel, Antara'
]
);