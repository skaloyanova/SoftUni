const ulElement = document.getElementById('list');

const hrefElement = document.createElement('a');
hrefElement.href = 'https://abv.bg';
hrefElement.textContent = 'АБВ Поща';
hrefElement.target = '_blank';

const liItem = document.createElement('li');
ulElement.appendChild(liItem);
liItem.appendChild(hrefElement);