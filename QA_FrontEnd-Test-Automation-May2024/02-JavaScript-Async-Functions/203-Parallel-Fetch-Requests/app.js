async function fetchParallel() {
  const responseJson1 = await fetch("https://swapi.dev/api/people/1").then(res => res.json());
  const responseJson2 = await fetch("https://swapi.dev/api/people/2").then(res => res.json());

  // Promise.all([responseJson1, responseJson2])
  //   .then(result => console.log(result));

  const [res1, res2] = await Promise.all([responseJson1, responseJson2]);
  console.log(res1, res2);
}