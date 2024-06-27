const {fetchData} = require('../async-test-functions.js');

QUnit.module('testing async function fetchData', () => {
    QUnit.test('Fetch data for BG postcode 8000', async assert => {
        const data = await fetchData('https://www.zippopotam.us/bg/8000');

        //Assert all properties exist
        assert.ok(data.hasOwnProperty('post code'), '[post code] property exists');
        assert.ok(data.hasOwnProperty('country'), '[country] property exists');
        assert.ok(data.hasOwnProperty('country abbreviation'), '[country abbreviation] property exists');
        assert.ok(data.hasOwnProperty('places'), '[places] property exists');
        
        assert.ok(Array.isArray(data.places), 'places is an array');
        assert.equal(data.places.length, 1, 'places array has 1 object element')

        const places = data.places[0];
        assert.ok(places.hasOwnProperty('place name'), '[place name] property exists in [places]');
        assert.ok(places.hasOwnProperty('longitude'), '[longitude] property exists in [places]');
        assert.ok(places.hasOwnProperty('state'), '[state] property exists in [places]');
        assert.ok(places.hasOwnProperty('state abbreviation'), '[state abbreviation] property exists in [places]');
        assert.ok(places.hasOwnProperty('latitude'), '[latitude] property exists in [places]');

        //Assert correct values for each property
        assert.equal(data['post code'], '8000', 'postcode is [8000]');
        assert.equal(data['country'], 'Bulgaria', 'postcode is [Bulgaria]');
        assert.equal(data['country abbreviation'], 'BG', 'country abbreviation is [BG]');
        assert.equal(places['place name'], 'Бургас / Burgas', 'places -> place name is [Бургас / Burgas]');
        assert.equal(places['longitude'], '27.4667', 'places -> longitude is [27.4667]');
        assert.equal(places['state'], 'Бургас / Burgas', 'places -> state is [Бургас / Burgas]');
        assert.equal(places['state abbreviation'], 'BGS', 'places -> state abbreviation is [BGS]');
        assert.equal(places['latitude'], '42.5', 'places -> latitude is [42.5]');
    })

    QUnit.test('Fetch data using invald postcode, should return empty object', async (assert) => {
        const data = await fetchData('https://www.zippopotam.us/bg/8000999');

        assert.notOk(data, 'should return [undefined]');
        assert.true(data === undefined, 'should return [true]');
    })

    QUnit.test('Fetch data using invald URL', async assert => {
        const data = await fetchData('https://wwww.zippopotam.us/bg/8000');

        assert.equal(data, 'fetch failed', 'error message [fetch failed] receibved');
    })
})