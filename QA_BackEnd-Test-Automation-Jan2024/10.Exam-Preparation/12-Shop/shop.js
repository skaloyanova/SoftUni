function shop(input) {
    const numberOfProducts = parseInt(input[0]);
    const products = input.slice(1, numberOfProducts + 1);
    const commands = input.slice(numberOfProducts + 1);
    let endFlag = false;

    for (const command of commands) {
        const commandParams = command.split(' ');
        const action = commandParams[0];

        if (endFlag || products.length === 0) {
            break;
        }

        switch (action) {
            case "Sell":
                const productSold = products.shift();
                console.log(`${productSold} product sold!`);
                break;
            case "Add":
                const newProduct = command.slice(4);
                if (newProduct) {
                    products.push(newProduct);
                }
                break;
            case "Swap":
                const startIdx = parseInt(commandParams[1]);
                const endIdx = parseInt(commandParams[2]);
                if (startIdx < 0 || startIdx >= products.length || isNaN(startIdx) || endIdx < 0 || endIdx >= products.length || isNaN(endIdx)) {
                    break;
                }
                const productAtEndIndex = products[endIdx];
                products[endIdx] = products[startIdx];
                products[startIdx] = productAtEndIndex;
                console.log("Swapped!");
                break;
            case "End":
                endFlag = true;
                break;
        }
    }

    //print on console
    if (products.length === 0) {
        console.log('The shop is empty');
    } else {
        console.log(`Products left: ${products.join(', ')}`);
    }
}

//Test solution
console.log("> > > CASE 1 < < <");
shop(['3', 'Apple', 'Banana', 'Orange', 'Sell', 'End', 'Swap 0 1']);

console.log("> > > CASE 2 < < <");
shop(['5', 'Milk', 'Eggs', 'Bread', 'Cheese', 'Butter', 'Add Yogurt', 'Swap 1 4', 'End']);

console.log("> > > CASE 3 < < <");
shop(['3', 'Shampoo', 'Soap', 'Toothpaste', 'Sell', 'Sell', 'Sell', 'End']);