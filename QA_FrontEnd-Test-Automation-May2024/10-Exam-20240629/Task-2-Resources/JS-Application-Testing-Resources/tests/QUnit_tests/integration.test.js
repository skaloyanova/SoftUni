const baseUrl = 'http://localhost:3030';

let user = {
    email: '',
    password: '123456'
};

let token = '';
let userId = '';

let myAlbum = {
    name: '',
    artist: '',
    description: '',
    genre: 'chill out',
    imgUrl: '/images/headphones.png',
    price: '9.99',
    releaseDate: '29 June 2024'
}

let lastCreatedAlbumId = '';

QUnit.config.reorder = false;

QUnit.module('User Functionality', () => {
    QUnit.test('User Registration', async (assert) => {
        //arrange
        const path = '/users/register';

        const random = Math.floor(Math.random() * 10000);
        user.email = `user${random}@gmail.com`;

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(json.hasOwnProperty('accessToken'), '<accessToken> property exists');
        assert.ok(json.hasOwnProperty('email'), '<email> property exists');
        assert.ok(json.hasOwnProperty('password'), '<password> property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '<_createdOn> property exists');
        assert.ok(json.hasOwnProperty('_id'), '<_id> property exists');

        assert.strictEqual(typeof json.accessToken, 'string', '<accessToken> value type is a string');
        assert.strictEqual(typeof json.email, 'string', '<email> value type is a string');
        assert.strictEqual(typeof json.password, 'string', '<password> value type is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '<_createdOn> value type is a number');
        assert.strictEqual(typeof json._id, 'string', '<_id> value type is a string');

        assert.equal(json['email'], user.email, '<email> value is correct');
        assert.equal(json['password'], user.password, '<password> value is correct');

        //keep accessToken and user Id in global vars and add the user to session storage
        token = json.accessToken;
        userId = json._id;
        sessionStorage.setItem('music-user', JSON.stringify(user));
    });

    QUnit.test('User Login', async (assert) => {
        //arrange
        const path = '/users/login';

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(user)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(json.hasOwnProperty('accessToken'), '<accessToken> property exists');
        assert.ok(json.hasOwnProperty('email'), '<email> property exists');
        assert.ok(json.hasOwnProperty('password'), '<password> property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '<_createdOn> property exists');
        assert.ok(json.hasOwnProperty('_id'), '<_id> property exists');

        assert.strictEqual(typeof json.accessToken, 'string', '<accessToken> value type is a string');
        assert.strictEqual(typeof json.email, 'string', '<email> value type is a string');
        assert.strictEqual(typeof json.password, 'string', '<password> value type is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '<_createdOn> value type is a number');
        assert.strictEqual(typeof json._id, 'string', '<_id> value type is a string');

        assert.equal(json['email'], user.email, '<email> value is correct');
        assert.equal(json['password'], user.password, '<password> value is correct');

        //keep accessToken and user Id in global vars and add the user to session storage
        token = json.accessToken;
        userId = json._id;
        sessionStorage.setItem('music-user', JSON.stringify(user));
    });
});

QUnit.module('Album Functionality', () => {
    QUnit.test('Get All albums', async (assert) => {
        //arrange
        const path = '/data/albums';
        const queryParam = '?sortBy=_createdOn%20desc&distinct=name';

        //act
        let response = await fetch(baseUrl + path + queryParam);

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(Array.isArray(json), "response is an array");

        json.forEach(jsonData => {
            assert.ok(jsonData.hasOwnProperty('artist'), '<artist> property exists');
            assert.ok(jsonData.hasOwnProperty('description'), '<description> property exists');
            assert.ok(jsonData.hasOwnProperty('genre'), '<genre> property exists');
            assert.ok(jsonData.hasOwnProperty('imgUrl'), '<imgUrl> property exists');
            assert.ok(jsonData.hasOwnProperty('name'), '<name> property exists');
            assert.ok(jsonData.hasOwnProperty('price'), '<price> property exists');
            assert.ok(jsonData.hasOwnProperty('releaseDate'), '<releaseDate> property exists');
            assert.ok(jsonData.hasOwnProperty('_createdOn'), '<_createdOn> property exists');
            assert.ok(jsonData.hasOwnProperty('_id'), '<_id> property exists');
            assert.ok(jsonData.hasOwnProperty('_ownerId'), '<_ownerId> property exists');

            assert.strictEqual(typeof jsonData.artist, 'string', '<artist> value type is a string');
            assert.strictEqual(typeof jsonData.description, 'string', '<description> value type is a string');
            assert.strictEqual(typeof jsonData.genre, 'string', '<genre> value type is a string');
            assert.strictEqual(typeof jsonData.imgUrl, 'string', '<imgUrl> value type is a string');
            assert.strictEqual(typeof jsonData.name, 'string', '<name> value type is a string');
            assert.strictEqual(typeof jsonData.price, 'string', '<price> value type is a string');
            assert.strictEqual(typeof jsonData.releaseDate, 'string', '<releaseDate> value type is a string');
            assert.strictEqual(typeof jsonData._createdOn, 'number', '<_createdOn> value type is a number');
            assert.strictEqual(typeof jsonData._id, 'string', '<_id> value type is a string');
            assert.strictEqual(typeof jsonData._ownerId, 'string', '<_ownerId> value type is a string');
        });
    });

    QUnit.test('Create Album', async (assert) => {
        //arrange
        const path = '/data/albums';

        const random = Math.floor(Math.random() * 10000);
        myAlbum.name = `Random Title - ${random}`;
        myAlbum.artist = `Random Artist - ${random}`;
        myAlbum.description = `Random Description - ${random}`;

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(myAlbum)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(json.hasOwnProperty('artist'), '<artist> property exists');
        assert.ok(json.hasOwnProperty('description'), '<description> property exists');
        assert.ok(json.hasOwnProperty('genre'), '<genre> property exists');
        assert.ok(json.hasOwnProperty('imgUrl'), '<imgUrl> property exists');
        assert.ok(json.hasOwnProperty('name'), '<name> property exists');
        assert.ok(json.hasOwnProperty('price'), '<price> property exists');
        assert.ok(json.hasOwnProperty('releaseDate'), '<releaseDate> property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '<_createdOn> property exists');
        assert.ok(json.hasOwnProperty('_id'), '<_id> property exists');
        assert.ok(json.hasOwnProperty('_ownerId'), '<_ownerId> property exists');

        assert.strictEqual(typeof json.artist, 'string', '<artist> value type is a string');
        assert.strictEqual(typeof json.description, 'string', '<description> value type is a string');
        assert.strictEqual(typeof json.genre, 'string', '<genre> value type is a string');
        assert.strictEqual(typeof json.imgUrl, 'string', '<imgUrl> value type is a string');
        assert.strictEqual(typeof json.name, 'string', '<name> value type is a string');
        assert.strictEqual(typeof json.price, 'string', '<price> value type is a string');
        assert.strictEqual(typeof json.releaseDate, 'string', '<releaseDate> value type is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '<_createdOn> value type is a number');
        assert.strictEqual(typeof json._id, 'string', '<_id> value type is a string');
        assert.strictEqual(typeof json._ownerId, 'string', '<_ownerId> value type is a string');

        assert.equal(json['artist'], myAlbum.artist, '<artist> value is correct');
        assert.equal(json['description'], myAlbum.description, '<description> value is correct');
        assert.equal(json['genre'], myAlbum.genre, '<genre> value is correct');
        assert.equal(json['imgUrl'], myAlbum.imgUrl, '<imgUrl> value is correct');
        assert.equal(json['name'], myAlbum.name, '<name> value is correct');
        assert.equal(json['price'], myAlbum.price, '<price> value is correct');
        assert.equal(json['releaseDate'], myAlbum.releaseDate, '<releaseDate> value is correct');

        //keep album ID in global var for Edit Album test
        lastCreatedAlbumId = json._id;
    });

    QUnit.test('Edit Album', async (assert) => {
        //arrange
        const path = '/data/albums';

        myAlbum.name += ' UPDATED';
        myAlbum.artist += ' UPDATED';
        myAlbum.description += ' UPDATED';

        //act
        let response = await fetch(baseUrl + path + '/' + lastCreatedAlbumId, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(myAlbum)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(json.hasOwnProperty('artist'), '<artist> property exists');
        assert.ok(json.hasOwnProperty('description'), '<description> property exists');
        assert.ok(json.hasOwnProperty('genre'), '<genre> property exists');
        assert.ok(json.hasOwnProperty('imgUrl'), '<imgUrl> property exists');
        assert.ok(json.hasOwnProperty('name'), '<name> property exists');
        assert.ok(json.hasOwnProperty('price'), '<price> property exists');
        assert.ok(json.hasOwnProperty('releaseDate'), '<releaseDate> property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '<_createdOn> property exists');
        assert.ok(json.hasOwnProperty('_id'), '<_id> property exists');
        assert.ok(json.hasOwnProperty('_ownerId'), '<_ownerId> property exists');
        assert.ok(json.hasOwnProperty('_updatedOn'), '<_updatedOn> property exists');

        assert.strictEqual(typeof json.artist, 'string', '<artist> value type is a string');
        assert.strictEqual(typeof json.description, 'string', '<description> value type is a string');
        assert.strictEqual(typeof json.genre, 'string', '<genre> value type is a string');
        assert.strictEqual(typeof json.imgUrl, 'string', '<imgUrl> value type is a string');
        assert.strictEqual(typeof json.name, 'string', '<name> value type is a string');
        assert.strictEqual(typeof json.price, 'string', '<price> value type is a string');
        assert.strictEqual(typeof json.releaseDate, 'string', '<releaseDate> value type is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '<_createdOn> value type is a number');
        assert.strictEqual(typeof json._id, 'string', '<_id> value type is a string');
        assert.strictEqual(typeof json._ownerId, 'string', '<_ownerId> value type is a string');
        assert.strictEqual(typeof json._updatedOn, 'number', '<_updatedOn> value type is a number');

        assert.equal(json['artist'], myAlbum.artist, '<artist> value is correct');
        assert.equal(json['description'], myAlbum.description, '<description> value is correct');
        assert.equal(json['genre'], myAlbum.genre, '<genre> value is correct');
        assert.equal(json['imgUrl'], myAlbum.imgUrl, '<imgUrl> value is correct');
        assert.equal(json['name'], myAlbum.name, '<name> value is correct');
        assert.equal(json['price'], myAlbum.price, '<price> value is correct');
        assert.equal(json['releaseDate'], myAlbum.releaseDate, '<releaseDate> value is correct');
    });

    QUnit.test('Delete Album', async (assert) => {
        //arrange
        const path = '/data/albums';

        //act
        let response = await fetch(baseUrl + path + '/' + lastCreatedAlbumId, {
            method: 'DELETE',
            headers: {
                'X-Authorization': token
            },
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');
    });
})