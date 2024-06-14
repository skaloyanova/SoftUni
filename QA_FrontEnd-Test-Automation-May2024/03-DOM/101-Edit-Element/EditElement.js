function editElement(htmlElementRef, match, replacer) {
    htmlElementRef.textContent = htmlElementRef.textContent.replaceAll(match, replacer);
}