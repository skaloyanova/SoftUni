window.addEventListener("load", solve);

function solve() {
  //Locate elements in form "snowman"
  const name = document.getElementById('snowman-name');
  const height = document.getElementById('snowman-height');
  const location = document.getElementById('location');
  const creator = document.getElementById('creator-name');
  const attribute = document.getElementById('special-attribute');
  const addButton = document.querySelector('form .add-btn');

  const ulSnowmanPreview = document.querySelector('.snowman-preview');
  const ulYourSnowman = document.querySelector('.snow-list');

  const body = document.querySelector('.body');
  const main = document.getElementById('hero');
  const backImage = document.getElementById('back-img');

  addButton.addEventListener('click', onAdd);

  function onAdd(e) {
    e.preventDefault();

    //if input is not valid, return
    if ((name.value == '') || (height.value == '') || (location.value == '') || (creator.value == '') || (attribute.value == '')) return;

    //create containers
    const li = document.createElement('li');
    li.classList.add('snowman-info');

    const article = document.createElement('article');

    const btnContainer = document.createElement('div');
    btnContainer.classList.add('btn-container');

    //create P elements, add textContent and append them to article
    const pName = document.createElement('p');
    const pHeight = document.createElement('p');
    const pLocation = document.createElement('p');
    const pCreator = document.createElement('p');
    const pAttribute = document.createElement('p');

    pName.textContent = 'Name: ' + name.value;
    pHeight.textContent = 'Height: ' + height.value;
    pLocation.textContent = 'Location: ' + location.value;
    pCreator.textContent = 'Creator: ' + creator.value;
    pAttribute.textContent = 'Attribute: ' + attribute.value;

    article.append(pName, pHeight, pLocation, pCreator, pAttribute);

    //create buttons and append them to btnContainer
    const editButton = document.createElement('button');
    editButton.classList.add('edit-btn');
    editButton.textContent = 'Edit';

    const nextButton = document.createElement('button');
    nextButton.classList.add('next-btn');
    nextButton.textContent = 'Next';

    btnContainer.append(editButton, nextButton);

    //append article and btnContainer LI element and LI to Snowman preview UL element
    li.append(article, btnContainer);
    ulSnowmanPreview.append(li);

    //clear input fields
    name.value = '';
    height.value = '';
    location.value = '';
    creator.value = '';
    attribute.value = '';

    //deactivate Add button
    addButton.disabled = true;

    //add event listeners to Edit and Next buttons
    editButton.addEventListener('click', onEdit);
    nextButton.addEventListener('click', onNext);
  }

  function onEdit(e) {
    e.preventDefault();

    //get data from article
    const pElements = document.querySelectorAll('.snowman-info p');
    const pElementsTextContent = Array.from(pElements).map(p => p.textContent);

    let inputValues = [];

    pElementsTextContent.forEach(p => {
      const [key, value] = p.split(': ');
      inputValues.push(value);
    })

    //map values in snowman form
    name.value = inputValues[0];
    height.value = inputValues[1];
    location.value = inputValues[2];
    creator.value = inputValues[3];
    attribute.value = inputValues[4];

    //remove everything inside of the <ul> with class = "snowman-preview"
    e.currentTarget.parentNode.parentNode.remove();

    //enable Add button
    addButton.disabled = false;
  }

  function onNext(e) {
    e.preventDefault();

    //get the article
    const articleClone = document.querySelector('.snowman-info article').cloneNode(true);

    //create HTML structure in snow-list UL
    const sendButton = document.createElement('button');
    sendButton.classList.add('send-btn');
    sendButton.textContent = 'Send';

    articleClone.append(sendButton);

    const li = document.createElement('li');
    li.classList.add('snowman-content');

    li.append(articleClone);
    ulYourSnowman.append(li);

    //remove everything inside of the <ul> with class = "snowman-preview"
    e.currentTarget.parentNode.parentNode.remove();

    //add event listeners to Send button
    sendButton.addEventListener('click', onSend);
  }

  function onSend(e) {
    main.remove();

    const backButton = document.createElement('button');
    backButton.classList.add('back-btn');
    backButton.textContent = 'Back';
    body.append(backButton);

    backImage.hidden = false;

    //add event listeners to Back button
    backButton.addEventListener('click', onBack);
  }

  function onBack() {
    window.location.reload();
  }
}
