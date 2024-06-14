function colorize() {
    let trEvenElements = document.querySelectorAll('table tr:nth-child(2n)');

    Array.from(trEvenElements).map(e => e.style.backgroundColor = 'teal');
}