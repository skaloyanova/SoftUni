function encodeAndDecodeMessages() {
    const [input, output] = document.getElementsByTagName('textarea');
    const [encodeButton, decodeButton] = document.getElementsByTagName('button');

    encodeButton.addEventListener('click', encodeMessage);
    decodeButton.addEventListener('click', decodeMessage);

    function encodeMessage() {
        const message = input.value;
        let encodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            const ascii = message.charCodeAt(i);
            encodedMessage += String.fromCharCode(ascii + 1);
        }

        input.value = '';
        output.value = encodedMessage;
    }

    function decodeMessage() {
        const message = output.value;
        let decodedMessage = '';

        for (let i = 0; i < message.length; i++) {
            const ascii = message.charCodeAt(i);
            decodedMessage += String.fromCharCode(ascii - 1);
        }

        output.value = decodedMessage;
    }
}