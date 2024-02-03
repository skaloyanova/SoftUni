//movie's object info must be name, director, and date. 

function movie(inputArray) {
    'use strict';

    let movies = [];

    for (const command of inputArray) {
        if (command.includes('addMovie')) {
            const movieName = command.substring(9);

            movies.push({name: movieName});

        } else if (command.includes('directedBy')) {
            const split = command.split(' directedBy ');
            const movieName = split[0];
            const movieDirector = split[1];

            const result = movies.find(m => m.name === movieName);

            if (result) {
                result.director = movieDirector;
            }

        } else if (command.includes('onDate')) {
            const split = command.split(' onDate ');
            const movieName = split[0];
            const movieDate = split[1];

            const result = movies.find(m => m.name === movieName);
            
            if (result) {
                result.date = movieDate;
            }
        }
    }

    movies
        .filter(movie => movie.name && movie.director && movie.date)    //filters the movies with all 3 properties set
        .forEach(movie => console.log(JSON.stringify(movie)));
}

//test data 

movie([
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
]);
//{"name":"Fast and Furious","date":"30.07.2018","director":"Rob Cohen"}
// {"name":"Godfather","director":"Francis Ford Coppola","date":"29.07.2018"}

movie([
    'addMovie The Avengers',
    'addMovie Superman',
    'The Avengers directedBy Anthony Russo',
    'The Avengers onDate 30.07.2010',
    'Captain America onDate 30.07.2010',
    'Captain America directedBy Joe Russo'
]);
//{"name":"The Avengers","director":"Anthony Russo","date":"30.07.2010"}