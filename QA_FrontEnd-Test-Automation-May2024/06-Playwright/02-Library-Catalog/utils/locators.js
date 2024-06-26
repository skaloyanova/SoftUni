const NAVBAR = {
    NAV_NAVBAR: 'nav.navbar',
    ALL_BOOKS_LINK: 'a[href="/catalog"]',
    LOGIN_BTN: 'a[href="/login"]',
    LOGOUT_BTN: '#logoutBtn',
    REGISTER_BTN: 'a[href="/register"]',
    MYBOOKS_BTN: 'a[href="/profile"]',
    ADDBOOK_BTN: 'a[href="/create"]',
    USER_EMAIL: 'nav.navbar #user',
}

const LOGIN_FORM = {
    LOGIN_FORM: '#login-form',
    EMAIL: '#login-form input[id="email"]',
    PASSWORD: '#login-form input[id="password"]',
    LOGIN_BTN: '#login-form input[type="submit"]',
}

const REGISTER_FORM = {
    REGISTER_FORM: '#register-form',
    EMAIL: '#register-form input[id="email"]',
    PASSWORD: '#register-form input[id="password"]',
    CONFIRM_PASSWORD: '#register-form input[id="repeat-pass"]',
    REGISTER_BTN: '#register-form input[type="submit"]',
}

const ADDBOOK_FORM = {
    ADDBOOK_FORM: '#create-form',
    TITLE: '#create-form input[id="title"]',
    DESCRIPTION: '#create-form textarea[id="description"]',
    IMAGE: '#create-form input[id="image"]',
    TYPE: '#create-form select[id="type"]',
    ADDBOOK_BTN: '#create-form input[type="submit"]',
}

const ALLBOOKS_PAGE = {
    ALLBOOKS_LIST: '.otherBooks',
    DETAILS_BTN: '.otherBooks a.button',
    NO_BOOKS: '.no-books',
}

const MYBOOKS_PAGE = {
    //MYBOOKS_LIST: '//li[@class="otherBooks"]',
    MYBOOKS_LIST: '.my-books-list .otherBooks',
    DETAILS_BTN: '.my-books-list .otherBooks a.button',
    NO_BOOKS: '.no-books',
}

const DETAILS_PAGE = {
    DETAILS_PAGE: '#details-page',
    EDIT_BTN: '//a[text()="Edit"]',
    DELETE_BTN: '//a[text()="Delete"]',
    LIKE_BTN: '//a[text()="Like"]',
    TOTAL_LIKES: '.likes #total-likes',
    TITLE: '.book-information h3',
    TYPE: '.book-information .type',
    IMAGE: '.book-information .img img',
    DESCRIPTION: '.book-description p',
}

export {
    NAVBAR,
    LOGIN_FORM,
    REGISTER_FORM,
    ADDBOOK_FORM,
    ALLBOOKS_PAGE,
    MYBOOKS_PAGE,
    DETAILS_PAGE,
}