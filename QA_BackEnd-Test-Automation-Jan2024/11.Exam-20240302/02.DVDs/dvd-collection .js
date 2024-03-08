function dvdCollection(input) {
    const numberOfDvds = parseInt(input[0]);
    const dvdList = input.slice(1, numberOfDvds + 1);
    const commandList = input.slice(numberOfDvds + 1);

    let doneFlag = false;

    for (const command of commandList) {

        //The program ends when there are no more commands or you receive a command "Done"
        if (doneFlag) {
            break;
        }

        const commandParams = command.split(' ');
        const action = commandParams[0];

        switch (action) {
            case "Watch":   //remove the DVD at the first position in the array and print message
                var dvdWatched = dvdList.shift();
                console.log(`${dvdWatched} DVD watched!`);
                break;

            case "Buy":     //add the given DVD title at the end of the array
                var dvdTitle = command.slice(4);
                dvdList.push(dvdTitle);
                break;

            case "Swap":    //swap the DVDs in the given index positions and print message
                var startIndex = parseInt(commandParams[1]);
                var endIndex = parseInt(commandParams[2]);

                //Validate index
                if (startIndex < 0 || startIndex >= dvdList.length || isNaN(startIndex) || endIndex < 0 || endIndex >= dvdList.length || isNaN(endIndex)) {
                    break;
                }

                var firstDvd = dvdList[startIndex];
                dvdList[startIndex] = dvdList[endIndex];
                dvdList[endIndex] = firstDvd;
                console.log("Swapped!");
                break;

            case "Done":
                doneFlag = true;
                break;
        }
    }

    //Print DVDs left in the list
    if(dvdList.length == 0) {
        console.log("The collection is empty");
    } else {
        console.log(`DVDs left: ${dvdList.join(', ')}`);
    }
}



//Verify function
console.log('[Case 1]');
dvdCollection(['3', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'Watch', 'Done', 'Swap 0 1']);

console.log('[Case 2]');
dvdCollection(['5', 'The Lion King', 'Frozen', 'Moana', 'Toy Story', 'Shrek', 'Buy Coco', 'Swap 2 4', 'Done']);

console.log('[Case 3]');
dvdCollection(['5', 'The Avengers', 'Iron Man', 'Thor', 'Captain America', 'Black Panther', 'Watch', 'Watch', 'Watch', 'Watch', 'Watch', 'Done']);