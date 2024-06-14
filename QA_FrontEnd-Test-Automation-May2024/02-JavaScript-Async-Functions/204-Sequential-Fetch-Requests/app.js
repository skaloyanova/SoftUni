async function fetchSequential() {
      const responseJson1 = await fetch("https://swapi.dev/api/people/1").then(res => res.json());
      console.log(responseJson1);

      const responseJson2 = await fetch("https://swapi.dev/api/people/2").then(res => res.json());
      console.log(responseJson2);
}