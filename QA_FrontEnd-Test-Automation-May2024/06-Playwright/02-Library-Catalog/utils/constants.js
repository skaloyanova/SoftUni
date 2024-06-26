const BASE_URL = 'http://localhost:3000';

const TEST_URL = {
    TEST_HOME_URL: BASE_URL + '/',
    TEST_LOGIN_URL: BASE_URL + '/login',
    TEST_REGISTER_URL: BASE_URL + '/register',
    TEST_CATALOG_URL: BASE_URL + '/catalog',
    TEST_MYBOOKS_URL: BASE_URL + '/profile',
    TEST_ADDBOOK_URL: BASE_URL + '/create',
}

const TEST_USER_PETER = {
    EMAIL: 'peter@abv.bg',
    PASSWORD: '123456'
}

const TEST_USER_JOHN = {
    EMAIL: 'john@abv.bg',
    PASSWORD: '123456'
}

const ALERT_MESSAGE = {
    ALLFIELDS_REQUIRED: 'All fields are required!',
    PASS_MISMATCH: "Passwords don't match!"
}

const TEST_BOOK = {
    TITLE: 'English Dictionary',
    DESCRIPTION: 'Description for English Dictionary',
    IMAGE: 'https://m.media-amazon.com/images/I/6122R00-UBL._AC_UF1000,1000_QL80_.jpg',
    TYPE: {
        FICTION: 'Fiction',
        ROMANCE: 'Romance',
        MISTERY: 'Mistery',
        CLASSIC: 'Classic',
        OTHER: 'Other'
    }
}

const BOOK_PETER = {
    TITLE: 'Outlander',
    DESCRIPTION: 'The year is 1945',
    TYPE: 'Other'
}

const BOOK_JOHN = {
    TITLE: 'To Kill a Mockingbird',
    DESCRIPTION: 'To Kill a Mockingbird',
    TYPE: 'Classic'
}

export {
    BASE_URL,
    TEST_URL,
    TEST_USER_PETER,
    TEST_USER_JOHN,
    ALERT_MESSAGE,
    TEST_BOOK,
    BOOK_PETER,
    BOOK_JOHN,
}