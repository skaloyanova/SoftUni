function solve() {
  const input = document.getElementById('input');
  const output = document.getElementById('output');

  const sentances = input.value.split('.');

  let counter = 0;
  let para = '';

  for (const sentance of sentances) {

    if (sentance.trim().length > 0) {   //i.e. sentance is not whitespace

      para += sentance + '.';
      counter++;

      if (counter === 3) {
        const p = document.createElement('p');
        p.textContent = para;
        output.append(p);
        para = '';
        counter = 0;
      }

    } else {
      continue;
    }

  }

  if (para.length > 0) {
    const p = document.createElement('p');
    p.textContent = para;
    output.append(p);
  }

}