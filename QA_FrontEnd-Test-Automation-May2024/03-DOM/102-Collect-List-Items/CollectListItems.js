function extractText() {
    let liElements = document.querySelectorAll('#items li');

    const liContents = Array.from(liElements)
        .map(liElement => liElement.textContent);

    let resultTextArea = document.getElementById('result');

    resultTextArea.value = liContents.join('\n');
}