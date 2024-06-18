function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   const tableRows = document.querySelectorAll('tbody tr');
   const input = document.getElementById('searchField');

   function onClick() {
      
      tableRows.forEach(tr => {
         if(tr.textContent.toLowerCase().includes(input.value.toLowerCase())) {
            tr.classList = 'select';
         } else {
            tr.classList = '';
         }
      });

      input.value = '';
   }
}