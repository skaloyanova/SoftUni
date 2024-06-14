function attachGradientEvents() {
    //get elements
    const gradientDivElement = document.getElementById('gradient');
    const resultElement = document.getElementById('result');

    gradientDivElement.addEventListener('mousemove', (event) => {
        const gradientWidth = event.target.clientWidth;
        const mousePosition = event.offsetX;
        
        const result = Math.trunc(mousePosition / (gradientWidth - 1) * 100);

        resultElement.textContent = result + '%';
    })

    //clear result box when pointer is out of the gradient
    gradientDivElement.addEventListener('mouseout', () => resultElement.textContent = '');
}