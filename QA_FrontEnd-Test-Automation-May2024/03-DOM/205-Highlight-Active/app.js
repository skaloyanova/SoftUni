function focused() {
    const sectionElements = document.querySelectorAll('body div div');
    const inputElements = document.querySelectorAll('body div div input');

    inputElements.forEach(e => e.addEventListener('focus', (event) => {
        sectionElements.forEach(section => section.classList.remove('focused'));
        event.target.parentElement.classList.add('focused');
    }));
}