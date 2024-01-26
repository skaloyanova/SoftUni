function print(start, end) {
    'use strict'

    let output = '';
    let sum = 0;

    for (let i = start; i <= end; i++) {
        output += `${i} `;
        sum += i;
    }

    console.log(output);
    console.log(`Sum: ${sum}`);
}

print(5, 10);
print(0, 26);
print(50, 60);