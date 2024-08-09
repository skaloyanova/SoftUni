using OpenQA.Selenium;

namespace RevueCrafters.Pages;

public class EditRevuePage : BasePage
{
    public EditRevuePage(IWebDriver driver) : base(driver)
    {
    }

    protected IWebElement TitleField => driver.FindElement(By.XPath("//input[@name='Title']"));
    protected IWebElement ImageUrlField => driver.FindElement(By.XPath("//input[@name='Url']"));
    protected IWebElement DescriptionField => driver.FindElement(By.XPath("//textarea[@name='Description']"));
    protected IWebElement EditButton => driver.FindElement(By.XPath("//button[text()='Edit']"));

    protected IWebElement FormElement => driver.FindElement(By.ClassName("card-body"));


    public string GetCurrentTitle()
    {
        return TitleField.GetAttribute("value");
    }

    public string GetCurrentImageUrl()
    {
        return ImageUrlField.GetAttribute("value");
    }

    public string GetCurrentDescription()
    {
        return DescriptionField.Text;
    }

    public void UpdateTitleOnly(string newTitle)
    {
        actions.ScrollToElement(FormElement).Perform();
        Type(TitleField, newTitle);
        EditButton.Click();
    }

    public void UpdateImageUrlOnly(string newImageUrl)
    {
        actions.ScrollToElement(FormElement).Perform();
        Type(ImageUrlField, newImageUrl);
        EditButton.Click();
    }

    public void UpdateDescriptionOnly(string newDescription)
    {
        actions.ScrollToElement(FormElement).Perform();
        Type(DescriptionField, newDescription);
        EditButton.Click();
    }

    public void UpdateTitleAndDescription(string newTitle, string newDescription)
    {
        actions.ScrollToElement(FormElement).Perform();
        Type(TitleField, newTitle);
        Type(DescriptionField, newDescription);
        EditButton.Click();
    }

    //public void UpdateAllFields(string newTitle, string newImageUrl, string newDescription)
    //{
    //    actions.ScrollToElement(FormElement).Perform();
    //    Type(TitleField, newTitle);
    //    Type(ImageUrlField, newImageUrl);
    //    Type(DescriptionField, newDescription);
    //    EditButton.Click();
    //}

}
