const {fakeDelay} = require('../async-test-functions.js');

QUnit.module('testing async function fakeDelay', () => {
    QUnit.test('testing delay function', async assert => {
        const startTime = Date.now();
        await fakeDelay(1000);
        const endTime = Date.now();

        const diff = endTime - startTime;
        
        assert.ok(diff >= 1000, 'delay should be at least 1000 ms');
    })
})