using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;

namespace _02_ColorNoteApp;

public class ColorNotesTests
{
    private AndroidDriver _driver;
    private AppiumLocalService _localService;
    private ColorNotePOM _pom;

    [OneTimeSetUp]
    public void Setup()
    {
        _localService = new AppiumServiceBuilder()
            .WithIPAddress("127.0.0.1")
            .UsingPort(4723)
            .Build();

        _localService.Start();

        AppiumOptions options = new AppiumOptions()
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            App = @"D:\_Coding\SoftUni\QA_FrontEnd-Test-Automation-May2024\15-Appium\Notepad.apk",
        };
        options.AddAdditionalAppiumOption("autoGrantPermissions", true);

        _driver = new AndroidDriver(_localService, options);

        _pom = new ColorNotePOM(_driver);
        _pom.SkipTutorial();
    }

    [OneTimeTearDown]
    public void Teardown()
    {
        _driver?.Quit();
        _driver?.Dispose();
        _localService?.Dispose();
    }

    [Test]
    public void CreateNoteTest()
    {
        string note = "TestNote 1";
        _pom.CreateTextNote(note);
        Assert.That(_pom.GetNotesTitlesList(), Does.Contain(note), "Note is not created");
    }

    [Test]
    public void EditNoteTest()
    {
        string note = "Note to edit";
        _pom.CreateTextNote(note);
        Assert.That(_pom.GetNotesTitlesList(), Does.Contain(note), "Note is not created");

        string editedNote = $"UPDATED {note}";
        _pom.EditNoteByTitle(note, editedNote);
        Assert.That(_pom.GetNotesTitlesList(), Does.Contain(editedNote), "Note is not updated");
    }

    [Test]
    public void DeleteNoteTest()
    {
        string note = "Note for Deletion";
        _pom.CreateTextNote(note);
        Assert.That(_pom.GetNotesTitlesList(), Does.Contain(note), "Note is not created");

        _pom.DeleteNoteByTitle(note);
        Assert.That(_pom.GetNotesTitlesList(), Does.Not.Contain(note), "Note is not deleted");
    }
}