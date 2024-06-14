function solve() {
  //get elements
  const textElement = document.getElementById('text');
  const namingConventionElement = document.getElementById('naming-convention');
  const resultElement = document.getElementById('result');

  //get values
  const textArray = textElement.value.split(/\s+/);
  const namingConvention = namingConventionElement.value;

  //set text Array to be Pascal Case
  let textArrayPascalCase = [];
  for (let i = 0; i < textArray.length; i++) {
    let word = textArray[i];
    textArrayPascalCase[i] = word[0].toUpperCase() + word.slice(1).toLowerCase();
  }

  //manipulate text
  let result = '';

  switch (namingConvention) {
    case "Camel Case":
      textArrayPascalCase[0] = textArrayPascalCase[0].toLowerCase();
      result = textArrayPascalCase.join('');
      break;
    case "Pascal Case":
      result = textArrayPascalCase.join('');
      break;
    default:
      result = 'Error!';
      break;
  }

  //append result
  resultElement.textContent = result;
}