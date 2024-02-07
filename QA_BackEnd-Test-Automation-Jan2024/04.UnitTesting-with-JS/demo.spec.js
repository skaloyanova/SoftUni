import { expect } from "chai";

describe('test', () => {
    describe('describe 1', () => {
        it ('test1 a', () => {})
        it ('test2', () => {})
        it ('test3', () => {})
    })
    describe('describe 2', () => {
        it ('test1 b', () => {})
        it ('test2', () => {})
        it ('test3', () => {})
    })
    describe('describe 3', () => {
        it ('test1 c', () => {})
        it ('test2', () => {})
        it ('test3', () => {})
    })
})

/*
npx mocha ./demo.spec.js --grep "test1"
  test
    describe 1
      ✔ test1 a
    describe 2
      ✔ test1 b
    describe 3
      ✔ test1 c
	  
npx mocha ./demo.spec.js --grep "describe 1"
  test
    describe 1
      ✔ test1 a
      ✔ test2
      ✔ test3
	  
npx mocha ./demo.spec.js --grep "describe 1 test2"
  test
    describe 1
      ✔ test2

npx mocha ./demo.spec.js --grep "1"
  test
    describe 1
      ✔ test1 a
      ✔ test2
      ✔ test3
    describe 2
      ✔ test1 b
    describe 3
      ✔ test1 c
*/