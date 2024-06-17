function search() {
   const townsLi = document.querySelectorAll('#towns li');
   const search = document.getElementById('searchText');
   const result = document.getElementById('result');

   let count = 0;

   for (const town of townsLi) {
      if(town.textContent.toLowerCase().includes(search.value.toLowerCase())) {
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
         count++;
      } else {
         town.style.fontWeight = '';
         town.style.textDecoration = '';
      }
   }

   result.textContent = `${count} matches found`

   search.value = '';
}
