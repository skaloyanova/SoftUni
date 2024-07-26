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

let albumName = "";

let myAlbum = {
	name: '',
	artist: '',
	description: '',
	genre: 'house',
	imgUrl: '/images/back.png',
	price: '19.99',
	releaseDate: '29 June 2024'
}

const NAVBAR = {
	HOME_LINK: '//a[text()="Home"]',
	CATALOG_LINK: '//a[text()="Catalog"]',
	SEARCH_LINK: '//a[text()="Search"]',
	LOGIN_LINK: '//a[text()="Login"]',
	REGISTER_LINK: '//a[text()="Register"]',
	CREATE_ALBUM_LINK: '//a[text()="Create Album"]',
	LOGOUT_BUTTON: '//a[text()="Logout"]'
}

const CATALOG_PAGE = {
	CARD_BOXES: '.card-box',
	DETAILS_BUTTONS_LOGGED_USER: '#details'
}

const SEARCH_PAGE = {
	SEARCH_INPUT: '#search-input',
	SEARCH_BUTTON: '.button-list',
	SEARCH_RESULTS: '.search-result',
	NO_RESULT: '.no-result',
	CARD_BOXES: '.card-box',
	DETAILS_BUTTONS: '#details'
}

const LOGIN_PAGE = {
	FORM: 'form',
	EMAIL: '#email',
	PASSWORD: '#password',
	SUBMIT_BUTTON: '.login[type="submit"]'
}

const REGISTER_PAGE = {
	FORM: 'form',
	EMAIL: '#email',
	PASSWORD: '#password',
	CONFIRM_PASSWORD: '#conf-pass',
	SUBMIT_BUTTON: '.register[type="submit"]'
}

const CREATE_ALBUM_PAGE = {
	FORM: 'form',
	NAME: '#name',
	IMG_URL: '#imgUrl',
	PRICE: '#price',
	RELEASE_DATE: '#releaseDate',
	ARTIST: '#artist',
	GENRE: '#genre',
	DESCRIPTION: '.description',
	SUMBIT_BUTTON: '.add-album[type="submit"]'
}

const EDIT_ALBUM_PAGE = {
	FORM: 'form',
	NAME: '#name',
	IMG_URL: '#imgUrl',
	PRICE: '#price',
	RELEASE_DATE: '#releaseDate',
	ARTIST: '#artist',
	GENRE: '#genre',
	DESCRIPTION: '.description',
	SUMBIT_BUTTON: '.edit-album[type="submit"]'
}

const DETAILS_PAGE = {
	EDIT_BUTTON: '.edit',
	DELETE_BUTTON: '.remove'
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
		test('Registration with Valid Data', async () => {
			//arrange
			await page.goto(host);
			await page.click(NAVBAR.REGISTER_LINK);
			await page.waitForSelector(REGISTER_PAGE.FORM);

			const random = Math.floor(Math.random() * 1000);
			user.email = `user${random}@gmail.com`;

			//act
			await page.locator(REGISTER_PAGE.EMAIL).fill(user.email);
			await page.locator(REGISTER_PAGE.PASSWORD).fill(user.password);
			await page.locator(REGISTER_PAGE.CONFIRM_PASSWORD).fill(user.confirmPass);

			let [response] = await Promise.all([
				page.waitForResponse(res => res.url().includes('/users/register') && res.status() === 200),
				page.click(REGISTER_PAGE.SUBMIT_BUTTON)
			]);

			let responseJson = await response.json();

			//assert
			expect(response.ok()).toBe(true);
			expect(responseJson.email).toBe(user.email);
			expect(responseJson.password).toEqual(user.password);
		});

		test('Login with Valid Data', async () => {
			//arrange
			await page.goto(host);
			await page.click(NAVBAR.LOGIN_LINK);
			await page.waitForSelector(LOGIN_PAGE.FORM);

			//act
			await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
			await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);

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

		test('Logout from the Application', async () => {
			//arrange - Login to app
			await page.goto(host);
			await page.click(NAVBAR.LOGIN_LINK);
			await page.waitForSelector(LOGIN_PAGE.FORM);
			await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
			await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);
			await page.click(LOGIN_PAGE.SUBMIT_BUTTON);

			//act
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
		test('Navigation for Logged-In User', async () => {
			//arrange - Login to app
			await page.goto(host);
			await page.click(NAVBAR.LOGIN_LINK);
			await page.waitForSelector(LOGIN_PAGE.FORM);
			await page.locator(LOGIN_PAGE.EMAIL).fill(user.email);
			await page.locator(LOGIN_PAGE.PASSWORD).fill(user.password);
			await page.click(LOGIN_PAGE.SUBMIT_BUTTON);

			//assert buttons
			await expect(page.locator(NAVBAR.HOME_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.CATALOG_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.SEARCH_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.CREATE_ALBUM_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.LOGOUT_BUTTON)).toBeVisible();

			await expect(page.locator(NAVBAR.LOGIN_LINK)).toBeHidden();
			await expect(page.locator(NAVBAR.REGISTER_LINK)).toBeHidden();
		});

		test('Navigation for Guest User', async () => {
			//arrange
			await page.goto(host);

			//assert buttons
			await expect(page.locator(NAVBAR.HOME_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.CATALOG_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.SEARCH_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.LOGIN_LINK)).toBeVisible();
			await expect(page.locator(NAVBAR.REGISTER_LINK)).toBeVisible();

			await expect(page.locator(NAVBAR.CREATE_ALBUM_LINK)).toBeHidden();
			await expect(page.locator(NAVBAR.LOGOUT_BUTTON)).toBeHidden();
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

		test('Create Album', async () => {
			//arrange
			await page.click(NAVBAR.CREATE_ALBUM_LINK);
			await page.waitForSelector(CREATE_ALBUM_PAGE.FORM);

			const random = Math.floor(Math.random() * 10000);
			myAlbum.name = `Title-${random}-playwright`;
			myAlbum.artist = `Artist-${random}-playwright`;
			myAlbum.description = `Description-${random}-playwright`;

			//act
			await page.locator(CREATE_ALBUM_PAGE.NAME).fill(myAlbum.name);
			await page.locator(CREATE_ALBUM_PAGE.IMG_URL).fill(myAlbum.imgUrl);
			await page.locator(CREATE_ALBUM_PAGE.PRICE).fill(myAlbum.price);
			await page.locator(CREATE_ALBUM_PAGE.RELEASE_DATE).fill(myAlbum.releaseDate);
			await page.locator(CREATE_ALBUM_PAGE.ARTIST).fill(myAlbum.artist);
			await page.locator(CREATE_ALBUM_PAGE.GENRE).fill(myAlbum.genre);
			await page.locator(CREATE_ALBUM_PAGE.DESCRIPTION).fill(myAlbum.description);

			let [response] = await Promise.all([
				page.waitForResponse(res => res.url().includes('/data/albums') && res.status() === 200),
				page.click(CREATE_ALBUM_PAGE.SUMBIT_BUTTON)
			]);

			let responseJson = await response.json();

			//assert
			expect(response.ok()).toBe(true);
			expect(responseJson.name).toEqual(myAlbum.name);
			expect(responseJson.imgUrl).toEqual(myAlbum.imgUrl);
			expect(responseJson.price).toEqual(myAlbum.price);
			expect(responseJson.releaseDate).toEqual(myAlbum.releaseDate);
			expect(responseJson.artist).toEqual(myAlbum.artist);
			expect(responseJson.genre).toEqual(myAlbum.genre);
			expect(responseJson.description).toEqual(myAlbum.description);
		});

		test('Edit Album', async () => {
			//arrange
			await page.click(NAVBAR.SEARCH_LINK);
			await page.locator(SEARCH_PAGE.SEARCH_INPUT).fill(myAlbum.name);
			await page.click(SEARCH_PAGE.SEARCH_BUTTON);
			await page.locator(SEARCH_PAGE.DETAILS_BUTTONS).first().click();
			await page.click(DETAILS_PAGE.EDIT_BUTTON);
			await page.waitForSelector(EDIT_ALBUM_PAGE.FORM);

			myAlbum.name += `-UPDATED`;
			myAlbum.artist += `-UPDATED`;

			//act
			await page.locator(EDIT_ALBUM_PAGE.NAME).fill(myAlbum.name);
			await page.locator(EDIT_ALBUM_PAGE.ARTIST).fill(myAlbum.artist);

			let [response] = await Promise.all([
				page.waitForResponse(res => res.url().includes('/data/albums') && res.status() === 200),
				page.click(EDIT_ALBUM_PAGE.SUMBIT_BUTTON)
			]);

			let responseJson = await response.json();

			//assert
			expect(response.ok()).toBe(true);
			expect(responseJson.name).toEqual(myAlbum.name);
			expect(responseJson.imgUrl).toEqual(myAlbum.imgUrl);
			expect(responseJson.price).toEqual(myAlbum.price);
			expect(responseJson.releaseDate).toEqual(myAlbum.releaseDate);
			expect(responseJson.artist).toEqual(myAlbum.artist);
			expect(responseJson.genre).toEqual(myAlbum.genre);
			expect(responseJson.description).toEqual(myAlbum.description);
		});

		test('Delete Album', async () => {
			//arrange
			await page.click(NAVBAR.SEARCH_LINK);
			await page.locator(SEARCH_PAGE.SEARCH_INPUT).fill(myAlbum.name);
			await page.click(SEARCH_PAGE.SEARCH_BUTTON);
			await page.locator(SEARCH_PAGE.DETAILS_BUTTONS).first().click();

			//act
			let [response] = await Promise.all([
				page.waitForResponse(res => res.url().includes('/data/albums') && res.status() === 200),
				page.click(DETAILS_PAGE.DELETE_BUTTON),
				page.on('dialog', dialog => dialog.accept())
			]);

			//assert
			expect(response.ok()).toBe(true);
		});

	});
});