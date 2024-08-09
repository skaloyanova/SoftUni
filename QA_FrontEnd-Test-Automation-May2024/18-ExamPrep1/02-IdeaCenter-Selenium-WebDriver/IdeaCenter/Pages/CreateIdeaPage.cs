using OpenQA.Selenium;


namespace IdeaCenter.Pages;

public class CreateIdeaPage : BasePage
{
    private readonly By titleField = By.XPath("//input[@name='Title']");
    private readonly By imageField = By.XPath("//input[@name='Url']");
    private readonly By descriptionField = By.XPath("//textarea[@name='Description']");
    private readonly By createButton = By.XPath("//button[text()='Create']");
    private readonly By errorMessage = By.XPath("//div[@class='text-danger validation-summary-errors']//li");
    private readonly By titleErrorMessage = By.XPath("//span[@data-valmsg-for='Title']");
    private readonly By descriptionErrorMessage = By.XPath("//span[@data-valmsg-for='Description']");

    private readonly string url = baseUrl + "/Ideas/Create";

    public CreateIdeaPage(IWebDriver driver) : base(driver)
    {
    }

    public void CreateIdea(string title, string description)
    {
        Type(titleField, title);
        Type(descriptionField, description);
        Click(createButton);
    }

    public void openPage()
    {
        driver.Navigate().GoToUrl(url);
    }

    public bool IsPageOpen()
    {
        return this.driver.Url == url;
    }

    public string GetErrorMessage()
    {
        return FindElement(errorMessage).Text;
    }

    public string GetTitleErrorMessage()
    {
        return FindElement(titleErrorMessage).Text;
    }

    public string GetDescriptionErrorMessage()
    {
        return FindElement(descriptionErrorMessage).Text;
    }

    public void AssertAllErrorMessages()
    {
        Assert.That(GetErrorMessage(), Is.EqualTo("Unable to create new Idea!"), "Error message does not match");
        Assert.That(GetTitleErrorMessage(), Is.EqualTo("The Title field is required."), "Title message is not as expected");
        Assert.That(GetDescriptionErrorMessage(), Is.EqualTo("The Description field is required."), "Description is not as expected");
    }
}
