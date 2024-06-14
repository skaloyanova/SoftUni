// async function fetchData() {
//     fetch("https://swapi.dev/api/people/1")
//         .then(response => response.json())
//         .then(json => console.log(json))
//         .catch(err => console.log(err));
// }

async function fetchData(){
    const response = await fetch("https://swapi.dev/api/people/1");
    const data = await response.json();
    console.log(data);
}