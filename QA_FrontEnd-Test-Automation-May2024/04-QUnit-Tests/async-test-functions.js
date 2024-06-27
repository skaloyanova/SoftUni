async function fetchData(url) {
    let result = await fetch(url)
    .then(response => {
        if(response.ok) {
            return response.json();
        }
    })
    .then(data => data)
    .catch(error => `${error.message}`);

    return result;
}

async function fakeDelay(miliseconds) {
    return new Promise(resolve => setTimeout(resolve, miliseconds)) 
}

module.exports = {
    fetchData,
    fakeDelay
}