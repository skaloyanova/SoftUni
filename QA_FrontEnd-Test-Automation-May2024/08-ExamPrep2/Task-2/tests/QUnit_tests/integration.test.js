const baseUrl = 'http://localhost:3030';

let user = {
    email: '',
    password: '123456'
};

let token = '';
let userId = '';

let eventData = {
    author: '',
    date: '28.06.2024',
    title: '',
    description: '',
    imageUrl: "/images/2.png"
}

let eventId = '';

QUnit.config.reorder = false;

QUnit.module('User Functionality', () => {
    QUnit.test('User Registration', async (assert) => {
        //arrange
        const path = '/users/register';

        const random = Math.floor(Math.random() * 10000);
        user.email = `user${random}@mail.me`;

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

        assert.ok(json.hasOwnProperty('accessToken'), 'accessToken property exists');
        assert.ok(json.hasOwnProperty('email'), 'email property exists');
        assert.ok(json.hasOwnProperty('password'), 'password property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(json.hasOwnProperty('_id'), '_id property exists');

        assert.equal(json['email'], user.email, 'email value is correct');
        assert.equal(json['password'], user.password, 'password value is correct');

        assert.strictEqual(typeof json.accessToken, 'string', 'accessToken value is a string');
        assert.strictEqual(typeof json.email, 'string', 'email value is a string');
        assert.strictEqual(typeof json.password, 'string', 'password value is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof json._id, 'string', '_id value is a string');

        token = json.accessToken;
        userId = json._id;
        sessionStorage.setItem('theater-user', JSON.stringify(user)); //set token to session store in browser
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
            body: JSON.stringify({
                email: user.email,
                password: user.password
            })
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(json.hasOwnProperty('accessToken'), 'accessToken property exists');
        assert.ok(json.hasOwnProperty('email'), 'email property exists');
        assert.ok(json.hasOwnProperty('password'), 'password property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(json.hasOwnProperty('_id'), '_id property exists');

        assert.strictEqual(typeof json.accessToken, 'string', 'accessToken value is a string');
        assert.strictEqual(typeof json.email, 'string', 'email value is a string');
        assert.strictEqual(typeof json.password, 'string', 'password value is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof json._id, 'string', '_id value is a string');

        assert.equal(json['email'], user.email, 'email value is correct');
        assert.equal(json['password'], user.password, 'password value is correct');

        token = json.accessToken;
        userId = json._id;
        sessionStorage.setItem('theater-user', JSON.stringify(user)); //set token to session store in browser
    });
});

QUnit.module('Event Functionality', () => {
    QUnit.test('Get all events', async (assert) => {
        //arrange
        let path = '/data/theaters';
        let queryParam = '?sortBy=_createdOn%20desc&distinct=title';

        //act
        let response = await fetch(baseUrl + path + queryParam);

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');

        assert.ok(Array.isArray(json), "response is array");

        json.forEach(jsonData => {
            assert.ok(jsonData.hasOwnProperty('author'), 'author property exists');
            assert.ok(jsonData.hasOwnProperty('date'), 'date property exists');
            assert.ok(jsonData.hasOwnProperty('description'), 'description property exists');
            assert.ok(jsonData.hasOwnProperty('imageUrl'), 'imageUrl property exists');
            assert.ok(jsonData.hasOwnProperty('title'), 'title property exists');
            assert.ok(jsonData.hasOwnProperty('_createdOn'), '_createdOn property exists');
            assert.ok(jsonData.hasOwnProperty('_id'), '_id property exists');
            assert.ok(jsonData.hasOwnProperty('_ownerId'), '_ownerId property exists');

            assert.strictEqual(typeof jsonData.author, 'string', 'author value is a string');
            assert.strictEqual(typeof jsonData.date, 'string', 'date value is a string');
            assert.strictEqual(typeof jsonData.description, 'string', 'description value is a string');
            assert.strictEqual(typeof jsonData.imageUrl, 'string', 'imageUrl value is a string');
            assert.strictEqual(typeof jsonData.title, 'string', 'title value is a string');
            assert.strictEqual(typeof jsonData._createdOn, 'number', '_createdOn value is a number');
            assert.strictEqual(typeof jsonData._id, 'string', '_id value is a string');
            assert.strictEqual(typeof jsonData._ownerId, 'string', '_ownerId value is a string');
        });
    });

    QUnit.test('Create event', async (assert) => {
        //arrange
        let path = '/data/theaters';

        const random = Math.floor(Math.random() * 10000);
        eventData.author = `Author-${random}`;
        eventData.title = `Title-${random}`;
        eventData.description = `Description-${random}`;

        //act
        let response = await fetch(baseUrl + path, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(eventData)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');
        
        assert.ok(json.hasOwnProperty('author'), 'author property exists');
        assert.ok(json.hasOwnProperty('date'), 'date property exists');
        assert.ok(json.hasOwnProperty('description'), 'description property exists');
        assert.ok(json.hasOwnProperty('imageUrl'), 'imageUrl property exists');
        assert.ok(json.hasOwnProperty('title'), 'title property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(json.hasOwnProperty('_id'), '_id property exists');
        assert.ok(json.hasOwnProperty('_ownerId'), '_ownerId property exists');

        assert.strictEqual(typeof json.author, 'string', 'author value is a string');
        assert.strictEqual(typeof json.date, 'string', 'date value is a string');
        assert.strictEqual(typeof json.description, 'string', 'description value is a string');
        assert.strictEqual(typeof json.imageUrl, 'string', 'imageUrl value is a string');
        assert.strictEqual(typeof json.title, 'string', 'title value is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof json._id, 'string', '_id value is a string');
        assert.strictEqual(typeof json._ownerId, 'string', '_ownerId value is a string');

        assert.equal(json['author'], eventData.author, 'author value is correct');
        assert.equal(json['date'], eventData.date, 'date value is correct');
        assert.equal(json['description'], eventData.description, 'description value is correct');
        assert.equal(json['imageUrl'], eventData.imageUrl, 'imageUrl value is correct');
        assert.equal(json['title'], eventData.title, 'title value is correct');
        
        eventId = json._id;
    });

    QUnit.test('Edit event', async (assert) => {
        //arrange
        let path = '/data/theaters';

        eventData.author += ` Updated`;
        eventData.title += ` Updated`;
        eventData.description += ` Updated`;

        //act
        let response = await fetch(`${baseUrl}${path}/${eventId}`, {
            method: 'PUT',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(eventData)
        });

        const json = await response.json();
        console.log(json);

        //assert
        assert.ok(response.ok, 'response is successful');
        
        assert.ok(json.hasOwnProperty('author'), 'author property exists');
        assert.ok(json.hasOwnProperty('date'), 'date property exists');
        assert.ok(json.hasOwnProperty('description'), 'description property exists');
        assert.ok(json.hasOwnProperty('imageUrl'), 'imageUrl property exists');
        assert.ok(json.hasOwnProperty('title'), 'title property exists');
        assert.ok(json.hasOwnProperty('_createdOn'), '_createdOn property exists');
        assert.ok(json.hasOwnProperty('_id'), '_id property exists');
        assert.ok(json.hasOwnProperty('_ownerId'), '_ownerId property exists');

        assert.strictEqual(typeof json.author, 'string', 'author value is a string');
        assert.strictEqual(typeof json.date, 'string', 'date value is a string');
        assert.strictEqual(typeof json.description, 'string', 'description value is a string');
        assert.strictEqual(typeof json.imageUrl, 'string', 'imageUrl value is a string');
        assert.strictEqual(typeof json.title, 'string', 'title value is a string');
        assert.strictEqual(typeof json._createdOn, 'number', '_createdOn value is a number');
        assert.strictEqual(typeof json._id, 'string', '_id value is a string');
        assert.strictEqual(typeof json._ownerId, 'string', '_ownerId value is a string');

        assert.equal(json['author'], eventData.author, 'author value is correct');
        assert.equal(json['date'], eventData.date, 'date value is correct');
        assert.equal(json['description'], eventData.description, 'description value is correct');
        assert.equal(json['imageUrl'], eventData.imageUrl, 'imageUrl value is correct');
        assert.equal(json['title'], eventData.title, 'title value is correct');  
    });

    QUnit.test('Delete event', async (assert) => {
        //arrange
        let path = '/data/theaters';

        //act
        let response = await fetch(`${baseUrl}${path}/${eventId}`, {
            method: 'DELETE',
            headers: {
                'X-Authorization': token
            },
        });

        //assert
        assert.ok(response.ok, 'response is successful');
    });
});