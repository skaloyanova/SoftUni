function solve() {
  //get elements
  const [input, output] = document.querySelectorAll('textarea');
  const [generateButton, buyButton] = document.getElementsByTagName('button');
  const tbody = document.querySelector('.table tbody');

  //event listeners
  generateButton.addEventListener('click', addNewProducts);
  buyButton.addEventListener('click', buyProducts);

  //functions
  function addNewProducts() {
    //get input data
    try {
      const jsonItems = JSON.parse(input.value);
      //create and append table rows for each product
      for (const jsonObj of jsonItems) {
        const newTableRow = createNewTableRow(jsonObj);
        tbody.append(newTableRow);
      }
    } catch (error) {

    }
  }

  function createNewTableRow(jsonObj) {
    //create table row
    const tableRow = document.createElement('tr');

    //create table data for image
    const tableDataImg = document.createElement('td');
    const img = document.createElement('img');
    img.src = jsonObj.img;
    tableDataImg.append(img);

    //create table data for name
    const tableDataName = document.createElement('td');
    const name = document.createElement('p');
    name.textContent = jsonObj.name;
    tableDataName.append(name);

    //create table data for price
    const tableDataPrice = document.createElement('td');
    const price = document.createElement('p');
    price.textContent = jsonObj.price
    tableDataPrice.append(price);

    //create table data for decoration
    const tableDataDecoration = document.createElement('td');
    const decoration = document.createElement('p');
    decoration.textContent = jsonObj.decFactor;
    tableDataDecoration.append(decoration);

    //create table data for chackbox
    const tableDataMark = document.createElement('td');
    const mark = document.createElement('input');
    mark.type = "checkbox";
    tableDataMark.append(mark);

    //append all TDs to table row
    tableRow.append(tableDataImg, tableDataName, tableDataPrice, tableDataDecoration, tableDataMark);

    return tableRow;
  }

  function buyProducts() {
    const checkedInputs = Array.from(tbody.querySelectorAll('input')).filter(e => e.checked);

    let products = [];
    let totalPrice = 0;
    let totalDeFactor = 0;

    for (const input of checkedInputs) {
      const product = input.parentElement.parentElement;
      const productTDs = product.querySelectorAll('td');

      const name = productTDs[1].textContent;
      const price = Number(productTDs[2].textContent);
      const deFactor = Number(productTDs[3].textContent);

      products.push(name);
      totalPrice += price;
      totalDeFactor += deFactor;
    }

    output.value = `Bought furniture: ${products.join(', ')}\nTotal price: ${totalPrice.toFixed(2)}\nAverage decoration factor: ${totalDeFactor / checkedInputs.length}`;
  }
}