window.addEventListener('load', solution);

function solution() {
  //Locate elements and get input data
  const employee = document.getElementById('employee');
  const category = document.getElementById('category');
  const urgency = document.getElementById('urgency');
  const team = document.getElementById('team');
  const description = document.getElementById('description');
  const addButton = document.getElementById('add-btn');

  const ulPreview = document.querySelector('.preview-list');
  const ulPending = document.querySelector('.pending-list');
  const ulResolved = document.querySelector('.resolved-list');

  addButton.addEventListener('click', onAdd);

  /*********************
   * ADD functionality *
   *********************/

  function onAdd(e) {
    e.preventDefault();

    //validate input
    if (employee.value == '' || category.value == '' || urgency.value == '' || team.value == '', description.value == '') return;

    //create HTML structure for Preview list
    const li = document.createElement('li');
    li.classList.add('problem-content');

    const article = document.createElement('article');

    const pEmployee = document.createElement('p');
    const pCategory = document.createElement('p');
    const pUrgency = document.createElement('p');
    const pTeam = document.createElement('p');
    const pDescription = document.createElement('p');

    pEmployee.textContent = 'From: ' + employee.value;
    pCategory.textContent = 'Category: ' + category.value;
    pUrgency.textContent = 'Urgency: ' + urgency.value;
    pTeam.textContent = 'Assigned to: ' + team.value;
    pDescription.textContent = 'Description: ' + description.value;

    const editButton = document.createElement('button');
    editButton.classList.add('edit-btn');
    editButton.textContent = 'Edit';

    const continueButton = document.createElement('button');
    continueButton.classList.add('continue-btn');
    continueButton.textContent = 'Continue';

    article.append(pEmployee, pCategory, pUrgency, pTeam, pDescription);
    li.append(article, editButton, continueButton);
    ulPreview.append(li);

    //keep input data before clearing the input fields
    let employeeValue = employee.value;
    let categoryValue = category.value;
    let urgencyValue = urgency.value;
    let teamValue = team.value;
    let descriptionValue = description.value;

    //clear input fields and disable Add button
    employee.value = '';
    category.value = '';
    urgency.value = '';
    team.value = '';
    description.value = '';
    addButton.disabled = true;

    //add eventListeners
    editButton.addEventListener('click', onEdit);
    continueButton.addEventListener('click', onContinue);


    /**********************
     * EDIT functionality *
     **********************/

    function onEdit(e) {
      //add current values from Preview in Problem input fields
      employee.value = employeeValue;
      category.value = categoryValue;
      urgency.value = urgencyValue;
      team.value = teamValue;
      description.value = descriptionValue;

      //remove Edit and Continue buttons from Preview and enable Add button
      li.removeChild(editButton);
      li.removeChild(continueButton);
      addButton.disabled = false;

      //remove data from Preview
      li.remove();
    }

    /**************************
     * CONTINUE functionality *
     **************************/

    function onContinue(e) {
      //remove Edit and Continue buttons and add Resolved button
      const resolveButton = document.createElement('button');
      resolveButton.classList.add('resolve-btn');
      resolveButton.textContent = 'Resolved';

      li.removeChild(editButton);
      li.removeChild(continueButton);
      li.appendChild(resolveButton);

      //move li to Pending list
      ulPending.appendChild(li);
      addButton.disabled = false;

      //add eventListener
      resolveButton.addEventListener('click', onResolve);


      /*************************
       * RESOLVE functionality *
       *************************/

      function onResolve() {
        //remove Resolved button and add Clear button
        const clearButton = document.createElement('button');
        clearButton.classList.add('clear-btn');
        clearButton.textContent = 'Clear';

        li.removeChild(resolveButton);
        li.appendChild(clearButton);

        //move li to Resolved list
        ulResolved.appendChild(li);

        //add eventListener
        clearButton.addEventListener('click', onClear);

        /***********************
         * CLEAR functionality *
         ***********************/

        function onClear() {
          ulResolved.removeChild(li);
        }
      }
    }
  }
}




