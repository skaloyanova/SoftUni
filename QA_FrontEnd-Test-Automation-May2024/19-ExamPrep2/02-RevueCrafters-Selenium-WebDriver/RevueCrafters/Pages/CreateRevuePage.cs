using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace RevueCrafters.Pages;

public class CreateRevuePage : BasePage
{
    public CreateRevuePage(IWebDriver driver) : base(driver)
    {
    }

    protected override string PageUrl => base.PageUrl + "/Revue/Create";

    protected IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));
    protected IWebElement ImageUrlField => driver.FindElement(By.XPath("//input[@name='Url']"));
    protected IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));
    protected IWebElement CreateButton => driver.FindElement(By.XPath("//button[text()='Create']"));

    protected IWebElement MainError => driver.FindElement(By.XPath("//div[@class='text-danger validation-summary-errors']//li"));
    protected IWebElement TitleError => driver.FindElement(By.XPath("//span[@data-valmsg-for='Title']"));
    protected IWebElement DescriptionError => driver.FindElement(By.XPath("//span[@data-valmsg-for='Description']"));

    protected IWebElement FormElement => driver.FindElement(By.Id("createRevue"));

    public override void OpenPage()
    {
        base.OpenPage();
        actions.ScrollToElement(FormElement).Perform();
    }

    public void CreateRevue(string title, string imageUrl, string description)
    {
        Type(TitleField, title);
        Type(ImageUrlField, imageUrl);
        Type(DescriptionField, description);
        CreateButton.Click();
    }

    public void AssertErrors()
    {
        Assert.Multiple(() =>
        {
            Assert.That(MainError.Text, Is.EqualTo("Unable to create new Revue!"));
            Assert.That(TitleError.Text, Is.EqualTo("The Title field is required."));
            Assert.That(DescriptionError.Text, Is.EqualTo("The Description field is required."));
        });
    }
}
