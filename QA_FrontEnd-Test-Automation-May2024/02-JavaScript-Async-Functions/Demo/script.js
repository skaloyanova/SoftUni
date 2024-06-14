let httpRequest;
let button = document.querySelector('#load');
button.addEventListener('click', eventListenerFunction);

function eventListenerFunction() {
    let url = 'https://api.github.com/users/testnakov/repos';
    httpRequest = new XMLHttpRequest();
    httpRequest.addEventListener('readystatechange', httpAjaxHandler);
    httpRequest.open("GET", url);
    httpRequest.send();
}

function httpAjaxHandler() {
    console.log("readyState: " + httpRequest.readyState + "; status: " + httpRequest.status);
    if (httpRequest.readyState == 4 && httpRequest.status == 200) {
        document.getElementById("res").textContent = httpRequest.responseText;
    }
}
