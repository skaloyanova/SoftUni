class AsyncQueue {
    constructor() {
        this.queue = [];
        this.taskInProgress = false;
    }

    addTask(task) {
        this.queue.push(task);
        this.processTasks();
    }

    async processTasks() {
        if (this.taskIsInProgress) return;

        this.taskIsInProgress = true;

        while (this.queue.length > 0) {
            const taskToProcess = this.queue.shift();

            try {
                const result = await taskToProcess;
                console.log(`Task completed: ${result}`);
            } catch (error) {
                console.log(`Task completed with error: ${error}`);
            }
        }
        
        this.taskInProgress = false;
    }
}

function startQueue() {
    let queue = new AsyncQueue();
    for (const task of tasks) {
        queue.addTask(task);
    }
}

const taskGenerator = function (id, delay) {
    return new Promise(resolve => {
        setTimeout(() => {
            resolve(`Task with id ${id} is resolved`)
        }, delay);
    })
}

const tasks = [
    taskGenerator(1, 500),
    taskGenerator(2, 2500),
    taskGenerator(3, 1000),
    taskGenerator(4, 400),
    taskGenerator(5, 3000),
];