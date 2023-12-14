using System;
using System.Threading.Tasks;
using NUnit.Framework;

using TestApp.Todo;

namespace TestApp.Tests;

[TestFixture]
public class ToDoListTests
{
    private ToDoList _toDoList = null!;
    
    [SetUp]
    public void SetUp()
    {
        this._toDoList = new();
    }
    
    [Test]
    public void Test_AddTask_TaskAddedToToDoList()
    {
        //Arrange
        string title = "task1";
        DateTime dueDate = new DateTime(2023, 12, 31);
        string expected = $"To-Do List:{Environment.NewLine}" +
        $"[ ] {title} - Due: 12/31/2023";

        //Act
        _toDoList.AddTask(title, dueDate);
        string result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CompleteTask_TaskMarkedAsCompleted()
    {
        //Arrange
        string title1 = "task1";
        string title2 = "task2";
        DateTime dueDate1 = new DateTime(2023, 12, 30);
        DateTime dueDate2 = new DateTime(2023, 12, 31);
        
        
        string expected = $"To-Do List:{Environment.NewLine}" +
        $"[ ] {title1} - Due: 12/30/2023{Environment.NewLine}" +
        $"[✓] {title2} - Due: 12/31/2023";

        //Act
        _toDoList.AddTask(title1, dueDate1);
        _toDoList.AddTask(title2, dueDate2);
        _toDoList.CompleteTask(title2);
        string result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CompleteTask_TaskNotFound_ThrowsArgumentException()
    {
        //Arrange
        string title1 = "task1";
        string title2 = "task2";
        DateTime dueDate1 = new DateTime(2023, 12, 30);
        DateTime dueDate2 = new DateTime(2023, 12, 31);

        //Act
        _toDoList.AddTask(title1, dueDate1);
        _toDoList.AddTask(title2, dueDate2);
 
        //Act & Assert
        Assert.That(() => _toDoList.CompleteTask("hello"), Throws.ArgumentException);
    }

    [Test]
    public void Test_DisplayTasks_NoTasks_ReturnsEmptyString()
    {
        //Arrange

        //Act
        string result = this._toDoList.DisplayTasks();

        //Act & Assert
        Assert.That(result, Is.EqualTo("To-Do List:"));
    }

    [Test]
    public void Test_DisplayTasks_WithTasks_ReturnsFormattedToDoList()
    {
        //Arrange
        string title1 = "task1";
        string title2 = "task2";
        DateTime dueDate1 = new DateTime(2023, 12, 30);
        DateTime dueDate2 = new DateTime(2023, 12, 31);


        string expected = $"To-Do List:{Environment.NewLine}" +
        $"[✓] {title1} - Due: 12/30/2023{Environment.NewLine}" +
        $"[✓] {title2} - Due: 12/31/2023";

        //Act
        _toDoList.AddTask(title1, dueDate1);
        _toDoList.AddTask(title2, dueDate2);
        _toDoList.CompleteTask(title1);
        _toDoList.CompleteTask(title2);
        string result = this._toDoList.DisplayTasks();

        //Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
