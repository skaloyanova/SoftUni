const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000'; // Application host (NOT service host - that can be anything)

let browser;
let context;
let page;

let user = {
    username: "",
    email: "",
    password: "123456",
    confirmPass: "123456",
};

let meme = {
    title: '',
    description: '',
    imageUrl: '/image/2.jpg'
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
        test('Registration with valid data', async () => {
            await page.goto(host);

            // Locate and click on the Register button.
            await page.locator('nav a[href="/register"]').click();

            // Wait for the register form to load.
            await page.waitForSelector('#register-form');
            expect(page.url()).toBe(host + '/register');

            // Create a unique username and email value.
            const random = Math.floor(Math.random() * 10000);
            user.username = `user${random}`;
            user.email = `${user.username}@gmail.com`;

            // Locate and fill the input field for username, email, password and repeat password
            await page.locator('#username').fill(user.username);
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.locator('#repeatPass').fill(user.confirmPass);

            // Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/users/register" and press the submit button for the form.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
                page.locator('input[type="submit"]').click()
            ])

            // Assert that the response is okey.
            expect(response.ok()).toBe(true);

            // Parse the response to JSON:
            const userData = await response.json();

            // Assert that the email and password are as expected.
            //console.log(userData);
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        });

        test('Login with valid data', async () => {
            await page.goto(host);

            // Locate and click on the Login button.
            await page.locator('nav a[href="/login"]').click();

            // Wait for the login form to load.
            await page.waitForSelector('#login-form');
            expect(page.url()).toBe(host + '/login');

            // Locate and fill the input field for email and password.
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);

            // Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain "/users/login" and press the submit button for the form.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/login') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            // Assert that the response is okey.
            expect(response).toBeOK;

            // Parse the response to JSON.
            const userData = await response.json();

            // Assert that the email and password are as expected.
            //console.log(userData);
            expect(userData.email).toBe(user.email);
            expect(userData.password).toBe(user.password);
        });

        test('Logout from the application', async () => {
            await page.goto(host);

            // Log in to the application.
            await page.locator('nav a[href="/login"]').click();

            await page.waitForSelector('#login-form');
            expect(page.url()).toBe(host + '/login');

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');

            // Get the response by creating a Promise scope. Wait for the response to have a status of 204 and for the URL to contain "/users/logout" and click on Logout button.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/users/logout') && res.status() === 204),
                page.locator('nav a[href="/logout"]').click()
            ])

            // Assert that the response is okey.
            expect(response.ok()).toBe(true);

            // Wait for Login button.
            await page.waitForSelector('nav a[href="/login"]');

            // Assert that the URL is for home page.
            await page.waitForURL(host + '/');
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
        test('Navigation for Logged-In user', async () => {
            await page.goto(host);

            // Log in to the application.
            await page.locator('nav a[href="/login"]').click();

            await page.waitForSelector('#login-form');
            expect(page.url()).toBe(host + '/login');

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');

            // Get buttons locators
            const loginButton = await page.locator('nav a[href="/login"]');
            const registerButton = await page.locator('nav a[href="/register"]');
            const homePageButton = await page.locator('nav a[href="/"]');
            const allMemesButton = await page.locator('nav a[href="/catalog"]');
            const createMemeButton = await page.locator('nav a[href="/create"]');
            const myProfileButton = await page.locator('nav a[href="/myprofile"]');
            const logoutButton = await page.locator('nav a[href="/logout"]');
            const loggedInUserInfo = await page.locator('nav .profile span');

            //assert buttons visibility
            await expect(allMemesButton).toBeVisible();
            await expect(createMemeButton).toBeVisible();
            await expect(myProfileButton).toBeVisible();
            await expect(logoutButton).toBeVisible();
            await expect(loggedInUserInfo).toBeVisible();

            await expect(homePageButton).toBeHidden();
            await expect(loginButton).toBeHidden();
            await expect(registerButton).toBeHidden();
        });

        test('Navigation for Guest user', async () => {
            await page.goto(host);

            // Get buttons locators
            const loginButton = await page.locator('nav a[href="/login"]');
            const registerButton = await page.locator('nav a[href="/register"]');
            const homePageButton = await page.locator('nav a[href="/"]');
            const allMemesButton = await page.locator('nav a[href="/catalog"]');
            const createMemeButton = await page.locator('nav a[href="/create"]');
            const myProfileButton = await page.locator('nav a[href="/myprofile"]');
            const logoutButton = await page.locator('nav a[href="/logout"]');
            const loggedInUserInfo = await page.locator('nav .profile span');

            //assert buttons visibility
            await expect(allMemesButton).toBeVisible();
            await expect(homePageButton).toBeVisible();
            await expect(loginButton).toBeVisible();
            await expect(registerButton).toBeVisible();

            await expect(createMemeButton).toBeHidden();
            await expect(myProfileButton).toBeHidden();
            await expect(logoutButton).toBeHidden();
            await expect(loggedInUserInfo).toBeHidden();
        });
    });

    describe("CRUD", () => {
        beforeEach('Login to the application', async () => {
            await page.goto(host);

            await page.locator('nav a[href="/login"]').click();

            await page.waitForSelector('#login-form');
            expect(page.url()).toBe(host + '/login');

            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('input[type="submit"]');
        });

        test('Create Meme', async () => {
            await page.locator('nav a[href="/create"]').click();

            await page.waitForSelector('#create-form');

            let random = Math.floor(Math.random() * 10000);
            meme.title = `Meme-${random}`;
            meme.description = `Description for ${meme.title}`;

            await page.locator('#title').fill(meme.title);
            await page.locator('#description').fill(meme.description);
            await page.locator('#imageUrl').fill(meme.imageUrl);

            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            expect(response.ok()).toBe(true);

            const data = await response.json();

            expect(data.title).toBe(meme.title);
            expect(data.description).toBe(meme.description);
            expect(data.imageUrl).toBe(meme.imageUrl);
        });

        test('Edit Meme', async () => {
            // Locate and click on "My Profile" button.
            await page.locator('nav a[href="/myprofile"]').click();

            // Locate and click on first meme’s Detail button.
            await page.locator('//a[text()="Details"]').first().click();

            // Locate and click on Edit button.
            await page.click('//a[text()="Edit"]');

            // Wait for the Edit form to load.
            await page.waitForSelector('#edit-form');

            // Locate and fill at least one of edit form fields to change/edit a meme.
            let title = await page.inputValue('#title');
            let description = await page.textContent('#description');
            let imageUrl = await page.inputValue('#imageUrl');

            title += ' - Edited';

            await page.locator('#title').fill(title);

            // Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain /data/memes" and press the submit button for the form.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('input[type="submit"]')
            ]);

            // Assert that response is okey.
            expect(response.ok()).toBe(true);

            // Parse the response to JSON.
            const data = await response.json();

            // Assert that title, description and imageUrl are as expected (with edited values).
            expect(data.title).toBe(title);
            expect(data.description).toBe(description);
            expect(data.imageUrl).toBe(imageUrl);

        });

        test('Delete Meme', async () => {
            // Locate and click on "My Profile" button.
            await page.locator('nav a[href="/myprofile"]').click();

            // Locate and click on first meme’s Detail button.
            await page.locator('//a[text()="Details"]').first().click();

            // Get the response by creating a Promise scope. Wait for the response to have a status of 200 and for the URL to contain /data/memes" and press the delete button.
            let [response] = await Promise.all([
                page.waitForResponse(res => res.url().includes('/data/memes') && res.status() === 200),
                page.click('//button[text()="Delete"]')
            ]);

            // Assert that the response is okey.
            expect(response.ok()).toBe(true);
        });
    });
});