function demo() {
    let numbers = [10, 20, 30, 40, 50];

    // console.log("initial: " + numbers);
    // console.log("pop: " + numbers.pop());
    // console.log("after pop: " + numbers);
    // console.log("push 60, 70: " + numbers.push(60, 70));
    // console.log("after push: " + numbers);
    // console.log("shift: " + numbers.shift());
    // console.log("after shift: " + numbers);
    // console.log("unshift 1, 2: " + numbers.unshift(1, 2));
    // console.log("after unshift: " + numbers);
    // console.log("splice - add 3, 4 on idx 2: " + numbers.splice(2, 0, 3, 4));
    // console.log("after splice: " + numbers);
    // console.log("splice - replace 2 elements on idx 2: " + numbers.splice(2, 2, 33, 44));
    // console.log("after splice: " + numbers);
    // console.log("splice - replace 1 element on idx 2: " + numbers.splice(2, 1, 330));
    // console.log("after splice: " + numbers);
    // console.log("splice - remove 1, add 2 elements on idx 2: " + numbers.splice(2, 1, 331, 332));
    // console.log("after splice: " + numbers);
    // console.log("splice - remove 3, add 1 element on idx 2: " + numbers.splice(2, 3, 500));
    // console.log("after splice: " + numbers);
    // let arr = numbers.splice(1, 1)
    // console.log(arr);
    // console.log(numbers);
    // console.log("0: " + numbers[0]);
    // console.log("1: " + numbers[1]);
    // console.log("2: " + numbers[2]);
    // console.log("3: " + numbers[3]);
    // console.log("4: " + numbers[4]);
    // console.log("5: " + numbers[5]);

    // console.log("numbers: " + numbers);
    // console.log("slice(): " + numbers.slice());
    // console.log("slice(1, 4): " + numbers.slice(1, 4));
    // console.log("slice(2, 4): " + numbers.slice(2, 4));
    // console.log("slice(2, 6): " + numbers.slice(2, 6));

    // console.log(numbers.includes(30, -2));
    // console.log(numbers.includes(40, -2));
    // console.log(numbers.includes(50, -2));

    // let array = [10, 20, 30, 10, 20];
    // console.log(array.indexOf(10, 4));

    // let numbersCopy = [];
    // numbers.forEach(item => { numbersCopy.push(item); });
    // console.log(numbersCopy);

    // let numbers1 = [1, 4, 9];
    // let roots = numbers1.map(function (num) {
    //     return Math.sqrt(num)
    // });

    // let roots2 = numbers1.map(e => {return Math.sqrt(e)});

    // console.log(numbers1);
    // console.log(roots);
    // console.log(roots2);

    // let person = { name:'Peter', age: 20 };
    // person.sayHello = () => console.log('Hi, guys');

    // console.log(person);
    // console.log(person.name);
    // console.log(person.age);
    // console.log(person.sayHello);
    // person.sayHello()
    // console.log(Object.keys(person));
    // console.log(Object.values(person));
    // console.log(Object.entries(person)[0]);


    let assocArr = {
        'one': 1,
        'two': 2,
    };
    console.log(assocArr);
    assocArr['four'] = 4;
    assocArr.five = 5;
    console.log(assocArr);
    assocArr['four'] = 44;
    assocArr.five = 55;
    console.log(assocArr);

    // for (const key in assocArr) {
    //     console.log(`${key} = ${assocArr[key]}`);
    // }

    // console.log(assocArr.hasOwnProperty('John Smith'));
    // console.log(assocArr.hasOwnProperty('one'));
    // delete assocArr['five'];
    // console.log(assocArr);

    // let entries = Object.entries(assocArr);
    // entries.forEach(e => console.log(e));
    // entries.sort((a, b) => b[0].localeCompare(a[0]));
    // entries.forEach(e => console.log(e));
    // entries.sort((a, b) => {
    //     if (a[1] < b[1]) return 1;
    //     else if (a[1] > b[1]) return -1;
    //     else return 0;
    // });
    // entries.forEach(e => console.log(e));
    // entries.sort(([aKey, aValue], [bKey, bValue]) => {
    //     if (aValue < bValue) return 1;
    //     else if (aValue > bValue) return -1;
    //     else return 0;
    // });

    // obj = { a: 1, b: 2 };
    // const { a, b } = obj;

    // console.log(typeof a + ", " + a);
    // console.log(typeof b + ", " + b);

    const {one, four} = assocArr;
    console.log(one);
    console.log(four);
}
demo();