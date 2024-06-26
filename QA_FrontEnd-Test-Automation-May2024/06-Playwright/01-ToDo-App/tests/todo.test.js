const { test, expect } = require('@playwright/test');

test('User can add a task', async ({ page }) => {
    //Arrange
    await page.goto('http://localhost:8080/');

    //Act
    await page.fill('#task-input', 'Task 1');
    await page.click('#add-task');

    //Assert
    const taskText = await page.textContent('.task');
    expect(taskText).toContain('Task 1');
});

test('User can delete a task', async ({ page }) => {
    //Arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Task to delete');
    await page.click('#add-task');

    //Act
    await page.click('.task .delete-task');

    //Assert
    const tasksText = await page.$$eval('.task', tasks => tasks.map(t => t.textContent));
    expect(tasksText).not.toContain('Task to delete');
});

test('User can mark a task as Complete', async ({ page }) => {
    //Arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Task to complete');
    await page.click('#add-task');

    //Act
    await page.click('.task .task-complete')

    //Assert
    const taskText = await page.textContent('.task.completed');
    expect(taskText).toContain('Task to complete');
});

test('User can filter tasks', async ({page}) => {
    //Arrange
    await page.goto('http://localhost:8080/');
    await page.fill('#task-input', 'Task to complete');
    await page.click('#add-task');
    await page.click('.task .task-complete')

    //Act - filter only completed tasks
    await page.selectOption('#filter', 'Completed')
    
    //Assert - validate that there are no active tasks in the filtered list
    const activeTasks = await page.$('.task:not(.completed)');
    expect(activeTasks).toBeNull();
});