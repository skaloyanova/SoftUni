const baseUrl = 'http://localhost:3030';

let user = {
    username: '',
    email: '',
    password: '123456',
    gender: 'female'
}

let token = '';
let userId = '';

let meme = {
    title: '',
    description: '',
    imageUrl: '../images/female.png'
};

let lastCreatedMemeId = '';

QUnit.config.reorder = false;

QUnit.module('User Functionality', () => {
    QUnit.test('User Registration', async (assert) => {
        //arrange
        let path = '/users/register';

        const random = Math.floor(Math.random() * 10000);
        user.username = `username${random}`;
        user.email = user.username + '@gmail.com';

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        //assert
        assert.ok(response.ok, 'successful response');

        const data = await response.json();
        // console.log(data);

        assert.ok(data.hasOwnProperty('accessToken'), 'accessToken property exists');
        assert.ok(data.hasOwnProperty('email'), 'email property exists');
        assert.ok(data.hasOwnProperty('gender'), 'gender property exists');
        assert.ok(data.hasOwnProperty('password'), 'password property exists');
        assert.ok(data.hasOwnProperty('username'), 'username property exists');
        assert.ok(data.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(data.hasOwnProperty('_id'), '_id property exists');

        assert.equal(data['email'], user.email, 'email value is correct');
        assert.equal(data['gender'], user.gender, 'gender value is correct');
        assert.equal(data['password'], user.password, 'password value is correct');
        assert.equal(data['username'], user.username, 'username value is correct');

        assert.strictEqual(typeof data.accessToken, 'string', 'accessToken value is a string');
        assert.strictEqual(typeof data.email, 'string', 'email value is a string');
        assert.strictEqual(typeof data.gender, 'string', 'gender value is a string');
        assert.strictEqual(typeof data.password, 'string', 'password value is a string');
        assert.strictEqual(typeof data.username, 'string', 'username value is a string');
        assert.strictEqual(typeof data._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof data._id, 'string', '_id value is a string');

        token = data['accessToken'];
        userId = data['_id'];
        sessionStorage.setItem('meme-user', JSON.stringify(user));
    });

    QUnit.test('User Login', async (assert) => {
        //arrange
        let path = '/users/login';

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({
                email: user.email,
                password: user.password
            })
        });

        //assert
        assert.ok(response.ok, 'successful response');

        const data = await response.json();
        // console.log(data);

        assert.ok(data.hasOwnProperty('accessToken'), 'accessToken property exists');
        assert.ok(data.hasOwnProperty('email'), 'email property exists');
        assert.ok(data.hasOwnProperty('gender'), 'gender property exists');
        assert.ok(data.hasOwnProperty('password'), 'password property exists');
        assert.ok(data.hasOwnProperty('username'), 'username property exists');
        assert.ok(data.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(data.hasOwnProperty('_id'), '_id property exists');

        assert.equal(data['email'], user.email, 'email value is correct');
        assert.equal(data['gender'], user.gender, 'gender value is correct');
        assert.equal(data['password'], user.password, 'password value is correct');
        assert.equal(data['username'], user.username, 'username value is correct');

        assert.strictEqual(typeof data.accessToken, 'string', 'accessToken value is a string');
        assert.strictEqual(typeof data.email, 'string', 'email value is a string');
        assert.strictEqual(typeof data.gender, 'string', 'gender value is a string');
        assert.strictEqual(typeof data.password, 'string', 'password value is a string');
        assert.strictEqual(typeof data.username, 'string', 'username value is a string');
        assert.strictEqual(typeof data._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof data._id, 'string', '_id value is a string');

        token = data['accessToken'];
        userId = data['_id'];
        sessionStorage.setItem('meme-user', JSON.stringify(user));
    });
});

QUnit.module('Meme Functionality', () => {
    QUnit.test('Get all Memes', async (assert) => {
        //arrange
        let path = '/data/memes';
        let queryParams = '?sortBy=_createdOn%20desc'

        //act
        let response = await fetch(baseUrl + path + queryParams);

        //assert
        assert.ok(response.ok, 'successful response');

        const data = await response.json();
        //console.log(data);

        assert.ok(Array.isArray(data), 'response is an array');

        data.forEach(meme => {
            assert.ok(meme.hasOwnProperty('description'), 'description property exists');
            assert.ok(meme.hasOwnProperty('imageUrl'), 'imageUrl property exists');
            assert.ok(meme.hasOwnProperty('title'), 'title property exists');
            assert.ok(meme.hasOwnProperty('_createdOn'), '_createdOn property exists');
            assert.ok(meme.hasOwnProperty('_id'), '_id property exists');
            assert.ok(meme.hasOwnProperty('_ownerId'), '_ownerId property exists');

            assert.strictEqual(typeof meme.description, 'string', 'description value is a string');
            assert.strictEqual(typeof meme.imageUrl, 'string', 'imageUrl value is a string');
            assert.strictEqual(typeof meme.title, 'string', 'title value is a string');
            assert.strictEqual(typeof meme._createdOn, 'number', '_createdOn value is a number');
            assert.strictEqual(typeof meme._id, 'string', '_id value is a string');
            assert.strictEqual(typeof meme._ownerId, 'string', '_ownerId value is a string');
        })
    });

    QUnit.test('Create Meme', async (assert) => {
        //arrange
        let path = '/data/meme';

        const random = Math.floor(Math.random() * 10000);
        meme.title = `Meme-${random}`;
        meme.description = `Description for ${meme.title}`;

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(meme)
        })

        //assert
        assert.ok(response.ok, 'successful response');

        const data = await response.json();
        //console.log(data);

        assert.ok(data.hasOwnProperty('description'), 'description property exists');
        assert.ok(data.hasOwnProperty('imageUrl'), 'imageUrl property exists');
        assert.ok(data.hasOwnProperty('title'), 'title property exists');
        assert.ok(data.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(data.hasOwnProperty('_id'), '_id property exists');
        assert.ok(data.hasOwnProperty('_ownerId'), '_ownerId property exists');

        assert.equal(data['description'], meme.description, 'description value is correct');
        assert.equal(data['imageUrl'], meme.imageUrl, 'imageUrl value is correct');
        assert.equal(data['title'], meme.title, 'title value is correct');

        assert.strictEqual(typeof data.description, 'string', 'description value is a string');
        assert.strictEqual(typeof data.imageUrl, 'string', 'imageUrl value is a string');
        assert.strictEqual(typeof data.title, 'string', 'title value is a string');
        assert.strictEqual(typeof data._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof data._id, 'string', '_id value is a string');
        assert.strictEqual(typeof data._ownerId, 'string', '_ownerId value is a string');

        lastCreatedMemeId = data._id;
    });

    QUnit.test('Edit Meme', async (assert) => {
        //arrange
        let path = `/data/meme/${lastCreatedMemeId}`;

        meme.title += ' - Edited';
        meme.description += ' - Edited';

        //act
        let response = await fetch(baseUrl + path, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(meme)
        })

        //assert
        assert.ok(response.ok, 'sucessful response');

        const data = await response.json();
        console.log(data);

        assert.ok(data.hasOwnProperty('description'), 'description property exists');
        assert.ok(data.hasOwnProperty('imageUrl'), 'imageUrl property exists');
        assert.ok(data.hasOwnProperty('title'), 'title property exists');
        assert.ok(data.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(data.hasOwnProperty('_id'), '_id property exists');
        assert.ok(data.hasOwnProperty('_ownerId'), '_ownerId property exists');
        assert.ok(data.hasOwnProperty('_updatedOn'), '_updatedOn property exists');

        assert.equal(data['description'], meme.description, 'description value is correct');
        assert.equal(data['imageUrl'], meme.imageUrl, 'imageUrl value is correct');
        assert.equal(data['title'], meme.title, 'title value is correct');

        assert.strictEqual(typeof data.description, 'string', 'description value is a string');
        assert.strictEqual(typeof data.imageUrl, 'string', 'imageUrl value is a string');
        assert.strictEqual(typeof data.title, 'string', 'title value is a string');
        assert.strictEqual(typeof data._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof data._id, 'string', '_id value is a string');
        assert.strictEqual(typeof data._ownerId, 'string', '_ownerId value is a string');
        assert.strictEqual(typeof data._updatedOn, 'number', '_updatedOn value is a number');
    });

    QUnit.test('Delete Meme', async (assert) => {
        //arrange
        let path = `/data/meme/${lastCreatedMemeId}`;

        //act
        let response = await fetch(baseUrl + path, {
            method: 'DELETE',
            headers: {
                'X-Authorization': token
            }
        });

        //assert
        assert.ok(response.ok, 'successful response');
    });
});