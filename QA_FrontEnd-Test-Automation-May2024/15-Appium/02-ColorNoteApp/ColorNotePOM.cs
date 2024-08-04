using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace _02_ColorNoteApp;

public class ColorNotePOM
{
    private readonly AndroidDriver _driver;
    By SkipButton => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/btn_start_skip");
    By AddNoteButton => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/main_btn1");
    By NoteTypeText => MobileBy.AndroidUIAutomator("new UiSelector().text(\"Text\")");
    By NoteTypeChecklist => MobileBy.AndroidUIAutomator("new UiSelector().text(\"Checklist\")");
    By EditNote => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_note");
    By BackButton => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/back_btn");
    By CreatedNotes => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/title");
    By EditButton => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/edit_btn");
    By MenuButton => MobileBy.Id("com.socialnmobile.dictapps.notepad.color.note:id/menu_btn");
    By DeleteButton => MobileBy.AndroidUIAutomator("new UiSelector().text(\"Delete\")");
    By OKConfirmButton => MobileBy.Id("android:id/button1");

    public ColorNotePOM(AndroidDriver driver)
    {
        _driver = driver;       
    }

    protected IWebElement FindElement(By by)
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }

    protected ReadOnlyCollection<AppiumElement> FindElements(By by)
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        return _driver.FindElements(by);
    }

    public void SkipTutorial()
    {
        try
        {
            FindElement(SkipButton).Click();
        }
        catch (NoSuchElementException)
        {
            // Tutorial "skip" is missing, so continue further
        }
    }

    public void CreateTextNote(string text)
    {
        FindElement(AddNoteButton).Click();
        FindElement(NoteTypeText).Click();
        FindElement(EditNote).SendKeys(text);
        FindElement(BackButton).Click();
        FindElement(BackButton).Click();
    }

    public List<string> GetNotesTitlesList()
    {
        return FindElements(CreatedNotes).Select(e => e.Text).ToList();
    }

    public IWebElement FindNoteByTitle(string title)
    {
        return FindElement(MobileBy.AndroidUIAutomator($"new UiSelector().text(\"{title}\")"));
    }

    public void EditNoteByTitle(string title, string updatedText)
    {
        FindNoteByTitle(title).Click();
        FindElement(EditButton).Click();
        FindElement(EditNote).Clear();
        FindElement(EditNote).SendKeys(updatedText);
        FindElement(BackButton).Click();
        FindElement(BackButton).Click();
    }

    public void DeleteNoteByTitle(string title)
    {
        FindNoteByTitle(title).Click();
        FindElement(MenuButton).Click();
        FindElement(DeleteButton).Click();
        FindElement(OKConfirmButton).Click();
    }
}
