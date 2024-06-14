function toggle() {
    const buttonSpan = document.querySelector('.button');
    const extraTextDiv = document.getElementById('extra');

    if(extraTextDiv.style.display === 'block') {
        buttonSpan.textContent = 'More';
        buttonSpan.style.textTransform = 'none';
        extraTextDiv.style.display = 'none';
    } else {
        buttonSpan.textContent = 'Less';
        buttonSpan.style.textTransform = 'none';
        extraTextDiv.style.display = 'block';
    }
}