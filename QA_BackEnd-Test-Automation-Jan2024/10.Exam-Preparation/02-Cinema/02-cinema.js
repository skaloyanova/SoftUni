function cinema(input) {
    const movieCount = parseInt(input[0]);
    const movies = input.slice(1, movieCount + 1);
    const commands = input.slice(movieCount + 1);

    for (const command of commands) {
        const commandParams = command.split(' ');
        const action = commandParams[0];

        switch (action) {
            case 'Sell':
                const movieSold = movies.shift();
                console.log(`${movieSold} ticket sold!`);
                break;

            case 'Add':
                //get the name of the new movie
                const newMovie = command.slice(4);

                //ignore command if movie does not exist
                if (!newMovie) {
                    break;
                }

                //add movie to the list
                movies.push(newMovie);
                break;

            case 'Swap':
                const startIndex = parseInt(commandParams[1]);
                const endIndex = parseInt(commandParams[2]);

                //ignore command if index is invalid
                if (isNaN(startIndex) || startIndex < 0 || startIndex >= movies.length || isNaN(endIndex) || endIndex < 0 || endIndex >= movies.length) {
                    break;
                }

                const firstMovie = movies[startIndex];
                const secondMovie = movies[endIndex];
                
                movies.splice(startIndex, 1, secondMovie);
                movies.splice(endIndex, 1, firstMovie);
                console.log("Swapped!");
                break;

            case 'End':
                if (movies.length == 0) {
                    console.log('The box office is empty');
                }
                else {
                    console.log(`Tickets left: ${movies.join(', ')}`);
                }
                return;
        }
    }
}

// Test function
console.log('>>> Case 1 <<<');
cinema(['3', 'Avatar', 'Titanic', 'Joker', 'Sell', 'End', 'Swap 0 1']);
console.log('>>> Case 2 <<<');
cinema(['5', 'The Matrix', 'The Godfather', 'The Shawshank Redemption', 'The Dark Knight', 'Inception', 'Add The Lord of the Rings', 'Swap 1 4', 'End']);
console.log('>>> Case 3 <<<');
cinema(['3', 'Star Wars', 'Harry Potter', 'The Hunger Games', 'Sell', 'Sell', 'Sell', 'End']);