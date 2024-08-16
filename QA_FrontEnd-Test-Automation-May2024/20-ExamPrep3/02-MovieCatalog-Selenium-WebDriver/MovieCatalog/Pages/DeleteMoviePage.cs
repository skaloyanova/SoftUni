using OpenQA.Selenium;

namespace MovieCatalog.Pages;

public class DeleteMoviePage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Movie/Delete";

    protected IWebElement YesButton => FindElement(By.XPath("//button[text()='Yes']"));
    protected IWebElement Message => FindElement(By.XPath("//div[@class='toast-message']"));

    public DeleteMoviePage(IWebDriver driver) : base(driver)
    {
    }

    public override bool IsPageOpen()
    {
        return driver.Url.Contains(PageUrl);
    }

    public void ConfirmMovieDeletion()
    {
        YesButton.Click();
    }

    public void AssertDeleteSuccessfulMessage()
    {
        Assert.That(Message.Text, Is.EqualTo("The Movie is deleted successfully!"));
    }
}
