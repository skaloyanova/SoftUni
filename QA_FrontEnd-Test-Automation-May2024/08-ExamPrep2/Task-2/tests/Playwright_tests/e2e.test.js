const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let myEvent = {
    title: '',
    date: '28.06.2024',
    author: '',
    description: '',
    imageUrl: '/images/2.png',
};

const NAVBAR = {
    THEATER_LINK: '//a[text()="Theater"]',
    LOGIN_LINK: '//a[text()="Login"]',
    REGISTER_LINK: '//a[text()="Register"]',
    PROFILE_LINK: '//a[text()="Profile"]',
    CREATE_EVENT_LINK: '//a[text()="Create Event"]',
    LOGOUT_BUTTON: '//a[text()="Logout"]'
}

const THEATER_PAGE = {
    DETAILS_BUTTONS: '//a[text()="Details"]'
}

const LOGIN_PAGE = {
    FORM: '.loginForm',
    EMAIL: '#email',
    PASSWORD: '#password',
    SUBMIT_BUTTON: '.btn[type="submit"]'
}

const REGISTER_PAGE = {
    FORM: '.registerForm',
    EMAIL: '#email',
    PASSWORD: '#password',
    REPEAT_PASSWORD: '#repeatPassword',
    SUBMIT_BUTTON: '.btn[type="submit"]'
}

const PROFILE_PAGE = {
    DASHBOARD: '.board',
    DETAILS_BUTTONS: '.details-button'
}

const CREATE_EVENT_PAGE = {
    FORM: '.create-form',
    TITLE: '#title',
    DATE: '#date',
    AUTHOR: '#author',
    DESCRIPTION: '#description',
    IMAGEURL: '#imageUrl',
    SUMBIT_BUTTON: '.btn[type="submit"]'
}

const EDIT_EVENT_PAGE = {
    FORM: '.theater-form',
    TITLE: '#title',
    DATE: '#date',
    AUTHOR: '#author',
    DESCRIPTION: '#description',
    IMAGEURL: '#imageUrl',
    SUMBIT_BUTTON: '.btn[type="submit"]'
}

const DETAILS_PAGE = {
    DELETE_BUTTON: '.btn-delete',
    EDIT_BUTTON: '.btn-edit',
}

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });


    describe("authentication", () => {
        test('Register user with valid data', async () => {
            //arrange
            await page.goto(host);
            await page.click(NAVBAR.REGISTER_LINK);
            await page.waitForSelector(REGISTER_PAGE.FORM);

            const random = Math.floor(Math.random() * 10000);
            user.email = `user${random}@mail.me`;

            //act
            await page.locator(REGISTER_PAGE.EMAIL).fill(user.email);
            await page.locator(REGISTER_PAGE.PASSWORD).fill(user.password);
            await page.locator(REGISTER_PAGE.REPEAT_PASSWORD).fill(user.confirmPass);

            //Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/users/register" and press the submit button for the form.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
                page.click(REGISTER_PAGE.SUBMIT_BUTTON)
            ])

            let responseJson = await response.json();

            //assert
            expect(response.ok()).toBe(true);
            expect(responseJson.email).toEqual(user.email);
            expect(responseJson.password).toEqual(user.password);
        });

        test('Login user with valid data', async () => {
            //arrange
            await page.goto(host);
            await page.click(NAVBAR.LOGIN_LINK);
            await page.waitForSelector(LOGIN_PAGE.FORM);

            //act
            await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
            await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);

            //Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/users/login" and press the submit button for the form.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/login') && res.status() === 200),
                page.click(LOGIN_PAGE.SUBMIT_BUTTON)
            ])

            let responseJson = await response.json();

            //assert
            expect(response.ok()).toBe(true);
            expect(responseJson.email).toEqual(user.email);
            expect(responseJson.password).toEqual(user.password);
        });

        test('Logout user', async () => {
            //arrange - Login to app
            await page.goto(host);
            await page.click(NAVBAR.LOGIN_LINK);
            await page.waitForSelector(LOGIN_PAGE.FORM);
            await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
            await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);
            await page.click(LOGIN_PAGE.SUBMIT_BUTTON);

            //act
            //Get the response by creating a Promise scope. Wait for the response to have a status of 204 and for the URL to contain "/users/logout" and click on Logout button.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/logout') && res.status() === 204),
                page.click(NAVBAR.LOGOUT_BUTTON)
            ])

            //expect
            expect(response.ok()).toBe(true);

            await page.waitForSelector(NAVBAR.LOGIN_LINK);
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation for Logged-In user', async () => {
            //arrange
            await page.goto(host);

            //act - Login to app
            await page.click(NAVBAR.LOGIN_LINK);
            await page.waitForSelector(LOGIN_PAGE.FORM);
            await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
            await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);
            await page.click(LOGIN_PAGE.SUBMIT_BUTTON);

            //assert buttons
            await expect(page.locator(NAVBAR.THEATER_LINK)).toBeVisible();
            await expect(page.locator(NAVBAR.CREATE_EVENT_LINK)).toBeVisible();
            await expect(page.locator(NAVBAR.PROFILE_LINK)).toBeVisible();
            await expect(page.locator(NAVBAR.LOGOUT_BUTTON)).toBeVisible();

            await expect(page.locator(NAVBAR.LOGIN_LINK)).toBeHidden();
            await expect(page.locator(NAVBAR.REGISTER_LINK)).toBeHidden();
        });

        test('Navigation for Guest user', async () => {
            //arrange
            await page.goto(host);

            //assert
            await expect(page.locator(NAVBAR.CREATE_EVENT_LINK)).toBeHidden();
            await expect(page.locator(NAVBAR.PROFILE_LINK)).toBeHidden();
            await expect(page.locator(NAVBAR.LOGOUT_BUTTON)).toBeHidden();

            await expect(page.locator(NAVBAR.THEATER_LINK)).toBeVisible();
            await expect(page.locator(NAVBAR.LOGIN_LINK)).toBeVisible();
            await expect(page.locator(NAVBAR.REGISTER_LINK)).toBeVisible();
        });
    });

    describe("CRUD", () => {
        beforeEach('login to app', async () => {
            await page.goto(host);
            await page.click(NAVBAR.LOGIN_LINK);
            await page.waitForSelector(LOGIN_PAGE.FORM);
            await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
            await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);
            await page.click(LOGIN_PAGE.SUBMIT_BUTTON);
        });

        test('Create event', async () => {
            //arrange
            await page.click(NAVBAR.CREATE_EVENT_LINK);
            await page.waitForSelector(CREATE_EVENT_PAGE.FORM);

            const random = Math.floor(Math.random() * 10000);
            myEvent.title = `Title-${random}`;
            myEvent.author = `Author-${random}`;
            myEvent.description = `Description-${random}`;

            //act
            await page.locator(CREATE_EVENT_PAGE.TITLE).fill(myEvent.title);
            await page.locator(CREATE_EVENT_PAGE.DATE).fill(myEvent.date);
            await page.locator(CREATE_EVENT_PAGE.AUTHOR).fill(myEvent.author);
            await page.locator(CREATE_EVENT_PAGE.DESCRIPTION).fill(myEvent.description);
            await page.locator(CREATE_EVENT_PAGE.IMAGEURL).fill(myEvent.imageUrl);

            //Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/data/theaters" and press the submit button for the form
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.click(CREATE_EVENT_PAGE.SUMBIT_BUTTON)
            ]);

            let responseJson = await response.json();

            //assert
            expect(response.ok()).toBe(true);
            expect(responseJson.title).toEqual(myEvent.title);
            expect(responseJson.date).toEqual(myEvent.date);
            expect(responseJson.author).toEqual(myEvent.author);
            expect(responseJson.description).toEqual(myEvent.description);
            expect(responseJson.imageUrl).toEqual(myEvent.imageUrl);
        });

        test('Edit event', async () => {
            //arrange
            await page.click(NAVBAR.PROFILE_LINK);
            await page.waitForSelector(PROFILE_PAGE.DASHBOARD);
            await page.locator(PROFILE_PAGE.DETAILS_BUTTONS).first().click();
            await page.click(DETAILS_PAGE.EDIT_BUTTON);
            await page.waitForSelector(EDIT_EVENT_PAGE.FORM);

            myEvent.title += `-updated`;
            myEvent.author += `-updated`;

            //act
            await page.locator(EDIT_EVENT_PAGE.TITLE).fill(myEvent.title);
            await page.locator(EDIT_EVENT_PAGE.AUTHOR).fill(myEvent.author);

            //Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/data/theaters" and press the submit button for the form
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.click(EDIT_EVENT_PAGE.SUMBIT_BUTTON)
            ]);

            let responseJson = await response.json();

            //assert
            expect(response.ok()).toBe(true);
            expect(responseJson.title).toEqual(myEvent.title);
            expect(responseJson.date).toEqual(myEvent.date);
            expect(responseJson.author).toEqual(myEvent.author);
            expect(responseJson.description).toEqual(myEvent.description);
            expect(responseJson.imageUrl).toEqual(myEvent.imageUrl);
        });

        test('Delete event', async () => {
            //arrange
            await page.click(NAVBAR.PROFILE_LINK);
            await page.waitForSelector(PROFILE_PAGE.DASHBOARD);
            await page.locator(PROFILE_PAGE.DETAILS_BUTTONS).first().click();

            //act
            //Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/data/theaters" and press the delete button.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/theaters') && res.status() === 200),
                page.click(DETAILS_PAGE.DELETE_BUTTON),
                page.on('dialog', dialog => dialog.accept())
            ]);

            //assert
            expect(response.ok()).toBe(true);
        });
    })
})