async function fetchWithTimeout(url = "https://swapi.dev/api/people/1", timeout = 2000) {

    const fetchPromise = fetch(url)
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! status: ${response.status}`);
            }
            return response.json()
        });

    const timeoutPromise = new Promise((_, reject) => {
        setTimeout(() => {
            reject(new Error("Timeout"));
        }, timeout)
    })

    try {
        const response = await Promise.race([fetchPromise, timeoutPromise]);
        console.log("Result: ", response);
    } catch (error) {
        console.log("Error: ", error.message);
    }
}