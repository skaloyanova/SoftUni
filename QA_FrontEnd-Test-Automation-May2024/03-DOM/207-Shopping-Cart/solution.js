function solve() {
   const textAreaElement = document.querySelector('textarea');
   const addButtonElements = document.querySelectorAll('.add-product');
   const checkoutElement = document.querySelector('.checkout');

   let totalSum = 0;
   let list = new Set();

   Array.from(addButtonElements).forEach(ab => ab.addEventListener('click', addProductHandler));

   function addProductHandler() {
      const product = this.parentElement.parentElement;
      const name = product.querySelector('.product-title').textContent;
      const price = Number(product.querySelector('.product-line-price').textContent);

      list.add(name);
      totalSum += price;

      textAreaElement.value += `Added ${name} for ${price.toFixed(2)} to the cart.\n`;
   };

   checkoutElement.addEventListener('click', () => {
      textAreaElement.value += `You bought ${Array.from(list).join(', ')} for ${totalSum.toFixed(2)}.`;
      Array.from(addButtonElements).forEach(ab => ab.removeEventListener('click', addProductHandler));
      
      checkoutElement.setAttribute('disabled', 'disabled');
   });
}