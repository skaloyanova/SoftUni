function create(words) {
   const content = document.getElementById('content');

   words.forEach(word => {
      const div = document.createElement('div');
      const p = document.createElement('p');
      p.textContent = word;
      p.style.display = 'none';

      div.addEventListener('click', () => {
         p.style.display = 'block';
      })

      div.append(p);
      content.append(div);
   });
}