const { test, expect } = require('@playwright/test');
import { NAVBAR, LOGIN_FORM, REGISTER_FORM, ADDBOOK_FORM, MYBOOKS_PAGE, DETAILS_PAGE, ALLBOOKS_PAGE } from '../utils/locators.js';
import { ALERT_MESSAGE, BASE_URL, TEST_BOOK, TEST_URL, TEST_USER_PETER, TEST_USER_JOHN, BOOK_PETER } from '../utils/constants.js';


test.describe('Navigation bar for Guest Users', () => {

    test('Verify "All Books" link is visible', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await page.waitForSelector(NAVBAR.NAV_NAVBAR);       //wait for the navbar to be loaded

        //Act
        const allBooksLink = await page.$(NAVBAR.ALL_BOOKS_LINK);
        const isLinkVisible = await allBooksLink.isVisible();

        //Assert
        expect(isLinkVisible).toBe(true);
    });

    // above test with page.locator
    test('Verify "All Books" link is visible 2', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await expect(page.locator(NAVBAR.NAV_NAVBAR)).toBeVisible();

        //Act and Assert
        await expect(page.locator(NAVBAR.ALL_BOOKS_LINK)).toBeVisible();
    });


    test('Verify "Login" button is visible', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await page.waitForSelector(NAVBAR.NAV_NAVBAR);       //wait for the navbar to be loaded

        //Act
        const loginButton = await page.$(NAVBAR.LOGIN_BTN);
        const isButtonVisible = await loginButton.isVisible();

        //Assert
        expect(isButtonVisible).toBe(true);
    });

    // above test with page.locator
    test('Verify "Login" button is visible 2', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await expect(page.locator(NAVBAR.NAV_NAVBAR)).toBeVisible();

        //Act and Assert
        await expect(page.locator(NAVBAR.LOGIN_BTN)).toBeVisible();
    });

    test('Verify "Register" button is visible', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await page.waitForSelector(NAVBAR.NAV_NAVBAR);       //wait for the navbar to be loaded

        //Act
        const registerButton = await page.$(NAVBAR.REGISTER_BTN);
        const isButtonVisible = await registerButton.isVisible();

        //Assert
        expect(isButtonVisible).toBe(true);
    });

    // above test with page.locator
    test('Verify "Register" button is visible 2', async ({ page }) => {
        //Arrange
        await page.goto(BASE_URL);
        await expect(page.locator(NAVBAR.NAV_NAVBAR)).toBeVisible();

        //Act and Assert
        await expect(page.locator(NAVBAR.REGISTER_BTN)).toBeVisible();
    });
});

test.describe('Navigation bar for Logged-In Users', () => {

    test.beforeEach('Login and wait for navbar to be loaded', async ({ page }) => {
        //Arrange
        await page.goto(TEST_URL.TEST_LOGIN_URL);
        await expect(page.locator(LOGIN_FORM.LOGIN_FORM)).toBeVisible();

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_PETER.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_PETER.PASSWORD);
        await page.locator(LOGIN_FORM.LOGIN_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);
        expect(page.url()).toBe(TEST_URL.TEST_CATALOG_URL);
    })

    test('Verify "All Books" link is visible', async ({ page }) => {
        await expect(page.locator(NAVBAR.ALL_BOOKS_LINK)).toBeVisible();
    });

    test('Verify "My Books" link is visible', async ({ page }) => {

        await expect(page.locator(NAVBAR.MYBOOKS_BTN)).toBeVisible();
    });

    test('Verify "Add Book" link is visible', async ({ page }) => {
        await expect(page.locator(NAVBAR.ADDBOOK_BTN)).toBeVisible();
    });

    test('Verify user email address is visible', async ({ page }) => {
        await page.waitForSelector(NAVBAR.USER_EMAIL);
        expect(await page.locator(NAVBAR.USER_EMAIL).textContent()).toContain(TEST_USER_PETER.EMAIL);
    });
});

test.describe('Login Page', () => {

    test('Submit Form with valid credentials', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_PETER.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_PETER.PASSWORD);
        await page.locator(LOGIN_FORM.LOGIN_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);
        expect(page.url()).toBe(TEST_URL.TEST_CATALOG_URL);

    });

    test('Submit Form with empty Input fields', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.LOGIN_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        });

        await page.waitForURL(TEST_URL.TEST_LOGIN_URL);
        expect(page.url()).toBe(TEST_URL.TEST_LOGIN_URL);
    });

    test('Submit Form with empty Email Input field', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_PETER.PASSWORD);
        await page.locator(LOGIN_FORM.LOGIN_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        });

        await page.waitForURL(TEST_URL.TEST_LOGIN_URL);
        expect(page.url()).toBe(TEST_URL.TEST_LOGIN_URL);
    });

    test('Submit Form with empty Password Input field', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_PETER.EMAIL);
        await page.locator(LOGIN_FORM.LOGIN_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        });

        await page.waitForURL(TEST_URL.TEST_LOGIN_URL);
        expect(page.url()).toBe(TEST_URL.TEST_LOGIN_URL);
    });
});

test.describe('Register Page', () => {
    let randomMail;
    let randomPass;

    test.beforeEach('Navigate to Register page', async ({ page }) => {
        await page.goto(BASE_URL);
        await page.locator(NAVBAR.REGISTER_BTN).click();

        const random = Math.random() * 100000;
        randomMail = 'mail' + random;
        randomPass = 'pass' + random;
    });

    test('Submit form with Valid values', async ({ page }) => {
        await page.locator(REGISTER_FORM.EMAIL).fill(randomMail);
        await page.locator(REGISTER_FORM.PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.CONFIRM_PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);
        expect(page.url()).toBe(TEST_URL.TEST_CATALOG_URL);
    });

    test('Submit form with Empty values', async ({ page }) => {
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_REGISTER_URL);
        expect(page.url()).toBe(TEST_URL.TEST_REGISTER_URL);
    });

    test('Submit form with Empty Email', async ({ page }) => {
        await page.locator(REGISTER_FORM.PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.CONFIRM_PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_REGISTER_URL);
        expect(page.url()).toBe(TEST_URL.TEST_REGISTER_URL);
    });

    test('Submit form with Empty Password', async ({ page }) => {
        await page.locator(REGISTER_FORM.EMAIL).fill(randomMail);
        await page.locator(REGISTER_FORM.CONFIRM_PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_REGISTER_URL);
        expect(page.url()).toBe(TEST_URL.TEST_REGISTER_URL);
    });

    test('Submit form with Empty Confirm Password', async ({ page }) => {
        await page.locator(REGISTER_FORM.EMAIL).fill(randomMail);
        await page.locator(REGISTER_FORM.PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_REGISTER_URL);
        expect(page.url()).toBe(TEST_URL.TEST_REGISTER_URL);
    });

    test('Submit form with Different Passwords', async ({ page }) => {
        await page.locator(REGISTER_FORM.EMAIL).fill(randomMail);
        await page.locator(REGISTER_FORM.PASSWORD).fill(randomPass);
        await page.locator(REGISTER_FORM.CONFIRM_PASSWORD).fill(randomPass + 'diff');
        await page.locator(REGISTER_FORM.REGISTER_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toContain('alert');
            expect(dialog.message()).toContain(ALERT_MESSAGE.PASS_MISMATCH);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_REGISTER_URL);
        expect(page.url()).toBe(TEST_URL.TEST_REGISTER_URL);
    });
});

test.describe('Add Book', () => {

    test.beforeEach('Login and navigate to Create book page', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_PETER.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_PETER.PASSWORD);

        await Promise.all([
            page.locator(LOGIN_FORM.LOGIN_BTN).click(),
            page.waitForURL(TEST_URL.TEST_CATALOG_URL)
        ]);

        await page.locator(NAVBAR.ADDBOOK_BTN).click();
        await page.waitForSelector(ADDBOOK_FORM.ADDBOOK_FORM);
    });

    test('Submit form with Correct Data', async ({ page }) => {
        await page.locator(ADDBOOK_FORM.TITLE).fill(TEST_BOOK.TITLE);
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill(TEST_BOOK.DESCRIPTION);
        await page.locator(ADDBOOK_FORM.IMAGE).fill(TEST_BOOK.IMAGE);
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);
        expect(page.url()).toBe(TEST_URL.TEST_CATALOG_URL);
    });

    test('Submit form with Empty Title field', async ({ page }) => {
        await page.locator(ADDBOOK_FORM.TITLE).fill('');
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill(TEST_BOOK.DESCRIPTION);
        await page.locator(ADDBOOK_FORM.IMAGE).fill(TEST_BOOK.IMAGE);
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message()).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_ADDBOOK_URL);
        expect(page.url()).toBe(TEST_URL.TEST_ADDBOOK_URL);
    });

    test('Submit form with Empty Description field', async ({ page }) => {
        await page.locator(ADDBOOK_FORM.TITLE).fill(TEST_BOOK.TITLE);
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill('');
        await page.locator(ADDBOOK_FORM.IMAGE).fill(TEST_BOOK.IMAGE);
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message()).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_ADDBOOK_URL);
        expect(page.url()).toBe(TEST_URL.TEST_ADDBOOK_URL);
    });

    test('Submit form with Empty Image URL field', async ({ page }) => {
        await page.locator(ADDBOOK_FORM.TITLE).fill(TEST_BOOK.TITLE);
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill(TEST_BOOK.DESCRIPTION);
        await page.locator(ADDBOOK_FORM.IMAGE).fill('');
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        page.on('dialog', async dialog => {
            expect(dialog.type()).toBe('alert');
            expect(dialog.message()).toBe(ALERT_MESSAGE.ALLFIELDS_REQUIRED);
            await dialog.accept();
        })

        await page.waitForURL(TEST_URL.TEST_ADDBOOK_URL);
        expect(page.url()).toBe(TEST_URL.TEST_ADDBOOK_URL);
    });
});

test.describe('My Books Page', () => {

    test.beforeEach('Login, create a Book and navigate to My Books', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_PETER.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_PETER.PASSWORD);

        await Promise.all([
            page.locator(LOGIN_FORM.LOGIN_BTN).click(),
            page.waitForURL(TEST_URL.TEST_CATALOG_URL)
        ]);

        await page.locator(NAVBAR.ADDBOOK_BTN).click();
        await page.waitForSelector(ADDBOOK_FORM.ADDBOOK_FORM);

        await page.locator(ADDBOOK_FORM.TITLE).fill(TEST_BOOK.TITLE);
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill(TEST_BOOK.DESCRIPTION);
        await page.locator(ADDBOOK_FORM.IMAGE).fill(TEST_BOOK.IMAGE);
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);

        await page.locator(NAVBAR.MYBOOKS_BTN).click();
        await page.waitForURL(TEST_URL.TEST_MYBOOKS_URL);
    });

    test('Verify that All Books are displayed', async ({ page }) => {
        const booksCount = await page.locator('.my-books-list .otherBooks').count();
        expect(booksCount).toBeGreaterThan(0);
    });

    /* Cannot be tested. App is buggy
    test('Verify that No Books are displayed', async ({ page }) => {
        //Arrange - delete all existing books
        const detailsButtons = await page.locator(MYBOOKS_PAGE.DETAILS_BTN).all();

        for (const btn of detailsButtons) {
            // Click the "Details" button and wait for navigation to the details page
            await Promise.all([
                btn.click(),
                page.waitForSelector(DETAILS_PAGE.DETAILS_PAGE)
            ]);
    
            // Click the "Delete" button
            await page.locator(DETAILS_PAGE.DELETE_BTN).click();
    
            // Handle the alert dialog
            page.on('dialog', async dialog => {
                await dialog.accept();
            });
    
            // Wait for the navigation back to All Books
            //await page.waitForURL(TEST_URL.TEST_CATALOG_URL);

            // Navigate again to My Books
            await page.locator(NAVBAR.MYBOOKS_BTN).click();
            await page.waitForURL(TEST_URL.TEST_MYBOOKS_URL);
        }
        //delete all books manually
        //some books cannot be deleted. App is buggy
        expect(page.locator(MYBOOKS_PAGE.NO_BOOKS).textContent()).toBe('No books in database!');
    });
    */

});

test.describe('Details Page', () => {

    test.beforeEach('Login, create a book and navigate to All Books page', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_JOHN.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_JOHN.PASSWORD);

        await Promise.all([
            page.locator(LOGIN_FORM.LOGIN_BTN).click(),
            page.waitForURL(TEST_URL.TEST_CATALOG_URL)
        ]);

        //create test book
        await page.locator(NAVBAR.ADDBOOK_BTN).click();
        await page.waitForSelector(ADDBOOK_FORM.ADDBOOK_FORM);

        await page.locator(ADDBOOK_FORM.TITLE).fill(TEST_BOOK.TITLE);
        await page.locator(ADDBOOK_FORM.DESCRIPTION).fill(TEST_BOOK.DESCRIPTION);
        await page.locator(ADDBOOK_FORM.IMAGE).fill(TEST_BOOK.IMAGE);
        await page.locator(ADDBOOK_FORM.TYPE).selectOption(TEST_BOOK.TYPE.OTHER);
        await page.locator(ADDBOOK_FORM.ADDBOOK_BTN).click();

        await page.waitForURL(TEST_URL.TEST_CATALOG_URL);
        expect(page.url()).toBe(TEST_URL.TEST_CATALOG_URL);
    });

    test('Verify that Logged-In user sees Details Button and button works correctly', async ({ page }) => {
        // Click on first details button and wait for Details page (this is the newly created book)
        await Promise.all([
            page.locator(ALLBOOKS_PAGE.DETAILS_BTN).first().click(),
            page.waitForSelector(DETAILS_PAGE.DETAILS_PAGE)
        ]);

        // verify user is logged-in
        await page.waitForSelector(NAVBAR.USER_EMAIL);
        expect(await page.locator(NAVBAR.USER_EMAIL).textContent()).toContain(TEST_USER_JOHN.EMAIL);

        //Assert
        expect(await page.locator(DETAILS_PAGE.TITLE).textContent()).toBe(TEST_BOOK.TITLE);
    });

    test('Verify that Guest User sees Details Button and button works correctly', async ({ page }) => {
        //logout current user
        await page.locator(NAVBAR.LOGOUT_BTN).click();
        await page.locator(NAVBAR.ALL_BOOKS_LINK).click();

        //Act and Assert
        await page.locator(ALLBOOKS_PAGE.DETAILS_BTN).first().click();
        await expect(page.locator(DETAILS_PAGE.TITLE)).toContainText(TEST_BOOK.TITLE);
    });

    test('Verify that All Info is displayed correctly', async ({ page }) => {
        // Click on first details button and wait for Details page (this is the newly created book)
        await Promise.all([
            page.locator(ALLBOOKS_PAGE.DETAILS_BTN).first().click(),
            page.waitForSelector(DETAILS_PAGE.DETAILS_PAGE)
        ]);

        // Assert book fields
        await expect(page.locator(DETAILS_PAGE.TITLE)).toContainText(TEST_BOOK.TITLE);
        await expect(page.locator(DETAILS_PAGE.DESCRIPTION)).toContainText(TEST_BOOK.DESCRIPTION);
        await expect(page.locator(DETAILS_PAGE.IMAGE)).toHaveAttribute('src', TEST_BOOK.IMAGE);
        await expect(page.locator(DETAILS_PAGE.TYPE)).toContainText(TEST_BOOK.TYPE.OTHER);
    });

    test('Verify if Edit and Delete buttons are Visible for Creator', async ({ page }) => {
        // Click on first details button and wait for Details page (this is the newly created book)
        await Promise.all([
            page.locator(ALLBOOKS_PAGE.DETAILS_BTN).first().click(),
            page.waitForSelector(DETAILS_PAGE.DETAILS_PAGE)
        ]);

        // verify user is logged-in
        await page.waitForSelector(NAVBAR.USER_EMAIL);
        expect(await page.locator(NAVBAR.USER_EMAIL).textContent()).toContain(TEST_USER_JOHN.EMAIL);

        // Assert buttons are visible
        const editBtn = page.locator(DETAILS_PAGE.EDIT_BTN);
        const deleteBtn = page.locator(DETAILS_PAGE.DELETE_BTN);
        await expect(editBtn).toBeVisible();
        await expect(deleteBtn).toBeVisible();
    });

    test('Verify if Edit and Delete buttons are Not Visible for Non-Creator', async ({ page }) => {
        //Currently logged in as John, click details button on Peter's book
        const petersBook = page.locator(`${ALLBOOKS_PAGE.ALLBOOKS_LIST}:has-text("${BOOK_PETER.TITLE}")`);
        const detailsBtn = petersBook.locator('a.button');
        await detailsBtn.click();

        // Verify Peter's book is displayed
        await expect(page.locator(DETAILS_PAGE.TITLE)).toContainText(BOOK_PETER.TITLE);

        // Assert buttons are not visible
        const editBtn = page.locator(DETAILS_PAGE.EDIT_BTN);
        const deleteBtn = page.locator(DETAILS_PAGE.DELETE_BTN);
        await expect(editBtn).not.toBeVisible();
        await expect(deleteBtn).not.toBeVisible();
    });

    test('Verify if Like button is not Visible for Creator', async ({ page }) => {
        // Click on first details button and wait for Details page (this is the newly created book)
        await Promise.all([
            page.locator(ALLBOOKS_PAGE.DETAILS_BTN).first().click(),
            page.waitForSelector(DETAILS_PAGE.DETAILS_PAGE)
        ]);

        // verify user is logged-in
        await page.waitForSelector(NAVBAR.USER_EMAIL);
        expect(await page.locator(NAVBAR.USER_EMAIL).textContent()).toContain(TEST_USER_JOHN.EMAIL);

        // Assert Like button is not visible
        const likeBtn = page.locator(DETAILS_PAGE.LIKE_BTN);
        await expect(likeBtn).not.toBeVisible();
    });

    test('Verify if Like button is Visible for Non-Creator', async ({ page }) => {
        //Currently logged in as John, click details button on Peter's book
        const petersBook = page.locator(`${ALLBOOKS_PAGE.ALLBOOKS_LIST}:has-text("${BOOK_PETER.TITLE}")`);
        const detailsBtn = petersBook.locator('a.button');
        await detailsBtn.click();

        // Verify Peter's book is displayed
        await expect(page.locator(DETAILS_PAGE.TITLE)).toContainText(BOOK_PETER.TITLE);

        // Assert Like button is visible
        const likeBtn = page.locator(DETAILS_PAGE.LIKE_BTN);
        await expect(likeBtn).toBeVisible();
    });

});

test.describe('Logout functionality', () => {

    test.beforeEach('Login and navigate to All Books page', async ({ page }) => {
        await page.goto(TEST_URL.TEST_LOGIN_URL);

        await page.locator(LOGIN_FORM.EMAIL).fill(TEST_USER_JOHN.EMAIL);
        await page.locator(LOGIN_FORM.PASSWORD).fill(TEST_USER_JOHN.PASSWORD);

        await Promise.all([
            page.locator(LOGIN_FORM.LOGIN_BTN).click(),
            page.waitForURL(TEST_URL.TEST_CATALOG_URL)
        ]);
    });
    
    test('Verify that "Logout" button is Visible', async ({ page }) => {
        const logoutBtn = page.locator(NAVBAR.LOGOUT_BTN);
        await expect(logoutBtn).toBeVisible();
    });

    test('Verify that "Logout" button redirects correctly', async ({ page }) => {
        await page.locator(NAVBAR.LOGOUT_BTN).click();

        await page.waitForURL(TEST_URL.TEST_HOME_URL);
        expect(page.url()).toBe(TEST_URL.TEST_HOME_URL);

        await expect(page.locator(NAVBAR.LOGIN_BTN)).toBeVisible();
        await expect(page.locator(NAVBAR.USER_EMAIL)).not.toBeVisible();
    });

});