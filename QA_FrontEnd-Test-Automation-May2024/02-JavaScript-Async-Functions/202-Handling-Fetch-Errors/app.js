// async function fetchDataWithErrorHandling() {
//     try {
//         fetch("https://swapi.dev/api/people/1")
//         .then(response => response.json())
//         .then(data => console.log(data));
//     } catch (error) {
//         console.log("Error: " + error);
//     }
// }

async function fetchDataWithErrorHandling() {
    try {
        const response = await fetch("https://swapi.dev/api/people/1");
        if(!response.ok) throw new Error("Network response is not OK");
        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.log("Fetching error appeared: " + error);
    }
}