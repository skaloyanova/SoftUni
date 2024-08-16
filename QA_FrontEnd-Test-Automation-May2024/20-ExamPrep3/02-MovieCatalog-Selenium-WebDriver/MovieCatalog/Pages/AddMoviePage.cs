using OpenQA.Selenium;

namespace MovieCatalog.Pages;

public class AddMoviePage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Catalog/Add";

    protected IWebElement TitleField => FindElement(By.XPath("//input[@name='Title']"));
    protected IWebElement DescriptionField => FindElement(By.XPath("//textarea[@name='Description']"));
    protected IWebElement AddButton => FindElement(By.XPath("//button[text()='Add']"));
    protected IWebElement Message => FindElement(By.XPath("//div[@class='toast-message']"));

    public AddMoviePage(IWebDriver driver) : base(driver)
    {
    }

    public void CreateMovie(string title, string description)
    {
        Type(TitleField, title);
        Type(DescriptionField, description);
        AddButton.Click();
    }

    public void AssertEmptyTitleMessage()
    {
        Assert.That(Message.Text, Is.EqualTo("The Title field is required."));
    }

    public void AssertEmptyDescriptionMessage()
    {
        Assert.That(Message.Text, Is.EqualTo("The Description field is required."));
    }
}
