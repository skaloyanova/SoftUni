using OpenQA.Selenium;

namespace MovieCatalog.Pages;

public class EditMoviePage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Movie/Edit";

    protected IWebElement TitleField => FindElement(By.XPath("//input[@name='Title']"));
    protected IWebElement DescriptionField => FindElement(By.XPath("//textarea[@name='Description']"));
    protected IWebElement EditButton => FindElement(By.XPath("//button[text()='Edit']"));
    protected IWebElement Message => FindElement(By.XPath("//div[@class='toast-message']"));

    public EditMoviePage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageOpen()
    {
        return driver.Url.Contains(PageUrl);
    }

    public void EditMovie(string newTitle, string newDescription)
    {
        Type(TitleField, newTitle);
        Type(DescriptionField, newDescription);
        EditButton.Click();
    }

    public void AssertEditSuccessfulMessage()
    {
        Assert.That(Message.Text, Is.EqualTo("The Movie is edited successfully!"));
    }
}
