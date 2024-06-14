function sumTable() {
    const priceTdElements = document.querySelectorAll('table tr td:nth-child(2):not(#sum)');

    let totalPrice = 0;

    for (const tdElement of priceTdElements) {
        const price = Number(tdElement.textContent);
        totalPrice += price;
    }

    document.getElementById('sum').textContent = totalPrice;
}