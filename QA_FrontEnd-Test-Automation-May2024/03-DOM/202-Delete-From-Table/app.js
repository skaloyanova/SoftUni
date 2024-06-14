function deleteByEmail() {
    //select elements
    const tableElement = document.getElementById('customers');
    const resultDivElement = document.getElementById('result');
   // const inputEmailElement = document.getElementsByName('email')[0];
    const inputEmailElement = document.querySelector('input[name=email');
    
    //get all table rows elements from table body
    const trElements = document.querySelectorAll('#customers tbody tr');

    //find matching row by searching the sencond column (2nd td)
    const resultTrElement = Array.from(trElements)
    .find(tr => tr.querySelector('td:nth-child(2)').textContent === inputEmailElement.value);

    if(resultTrElement) {
        //delete table row and display "Deleted" in result div
        resultTrElement.remove();
        resultDivElement.textContent = 'Deleted.'
    } else {
        //display "Not Found" in result div
        resultDivElement.textContent = 'Not found.'
    }

    inputEmailElement.value = '';
    inputEmailElement.focus();    
}
