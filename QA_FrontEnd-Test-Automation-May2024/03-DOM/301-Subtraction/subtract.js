function subtract() {
    //get elements
    const firstNumberElement = document.getElementById('firstNumber');
    const secondNumberElement = document.getElementById('secondNumber');
    const resultElement = document.getElementById('result');

    //calculate
    const subtraction = Number(firstNumberElement.value) - Number(secondNumberElement.value);

    //append result
    resultElement.textContent = subtraction;
} 