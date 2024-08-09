using OpenQA.Selenium;

namespace IdeaCenter.Pages;

public class EditIdeaPage : BasePage
{
    private readonly By titleField = By.XPath("//input[@name='Title']");
    private readonly By descriptionField = By.XPath("//textarea[@name='Description']");
    private readonly By editButton = By.XPath("//button[text()='Edit']");
    private readonly By errorMessage = By.XPath("//div[@class='text-danger validation-summary-errors']");

    public EditIdeaPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsPageOpen()
    {
        return driver.Url.Contains("/Ideas/Edit");
    }

    public string GetIdeaTitle()
    {
        return FindElement(titleField).GetAttribute("value");
    }

    public string GetIdeaDescription()
    {
        return FindElement(descriptionField).Text;
    }

    public void UpdateTitle(string newTitle)
    {
        Type(titleField, newTitle);
    }

    public void UpdateDescription(string newDescription)
    {
        Type(descriptionField, newDescription);
    }

    public void ClickEditButton()
    {
        Click(editButton);
    }

    public string GetErrorMessage()
    {
        return FindElement(errorMessage).Text;
    }
}
