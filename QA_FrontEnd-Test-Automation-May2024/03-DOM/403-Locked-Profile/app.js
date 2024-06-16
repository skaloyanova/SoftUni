function lockedProfile() {
    const buttons = document.getElementsByTagName('button');

    Array.from(buttons).forEach(b => b.addEventListener('click', showMoreHandler));

    function showMoreHandler(event) {
        const isUnlocked = event.currentTarget.parentElement.querySelector('input[value=unlock]').checked;

        const moreDetails = event.currentTarget.parentElement.getElementsByTagName('div')[0];

        if(isUnlocked) {
            if (moreDetails.style.display === 'block') {
                moreDetails.style.display = 'none';
                event.currentTarget.textContent = 'Show more';
            } else {
                moreDetails.style.display = 'block';
                event.currentTarget.textContent = 'Hide it';
                event.currentTarget.addEventListener('click', showMoreHandler);
            }
        }
    }
}