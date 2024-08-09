using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace RevueCrafters.Pages;

public class MyRevuesPage : BasePage
{
    public MyRevuesPage(IWebDriver driver) : base(driver)
    {
    }

    protected override string PageUrl => base.PageUrl + "/Revue/MyRevues";

    protected IWebElement SearchField => driver.FindElement(By.Id("keyword"));
    protected IWebElement NoRevueMessage => driver.FindElement(By.XPath("//span[@class='col-12 text-muted']"));
    protected ReadOnlyCollection<IWebElement> AllRevues => driver.FindElements(By.XPath("//div[@class='card mb-4 box-shadow']"));
    protected By RevueTitle => By.XPath(".//div[@class='text-muted text-center']");
    protected By RevueDescription => By.XPath(".//p[@class='card-text']");
    protected By EditButton => By.XPath(".//a[text()='Edit']");
    protected By DeleteButton => By.XPath(".//a[text()='Delete']");

    protected IWebElement FormElement => driver.FindElement(By.Id("myRevues"));

    public override void OpenPage()
    {
        base.OpenPage();
        actions.ScrollToElement(FormElement).Perform();
    }

    //public IWebElement? GetRevueByTitle(string title)
    //{
    //    return AllRevues.FirstOrDefault(e => e.FindElement(RevueTitle).Text == title);
    //}

    public ReadOnlyCollection<IWebElement> GetAllRevues()
    {
        return AllRevues;
    }

    protected IWebElement GetLastCreatedRevue()
    {
        return AllRevues.Last();
    }

    public string GetTitleOfLastCreatedRevue()
    {
        return GetLastCreatedRevue().FindElement(RevueTitle).Text;
    }

    public string GetDescriptionOfLastCreatedRevue()
    {
        return GetLastCreatedRevue().FindElement(RevueDescription).Text;
    }

    public void SearchByKeyword(string keyword)
    {
        Type(SearchField, keyword + Keys.Enter);
        actions.ScrollToElement(FormElement).Perform();
    }

    public string GetTitleOfFirstRevueInSearchList()
    {
        return driver.FindElement(RevueTitle).Text;
    }

    public void ClickEditButtonOnLastCreatedRevue()
    {
        var lastRevue = GetLastCreatedRevue();
        actions.ScrollToElement(lastRevue).Perform();
        lastRevue.FindElement(EditButton).Click();
    }

    public void ClickDeleteButtonOnLastCreatedRevue()
    {
        var lastRevue = GetLastCreatedRevue();
        actions.ScrollToElement(lastRevue).Perform();
        lastRevue.FindElement(DeleteButton).Click();
    }

    public string GetNoRevuesMessage()
    {
        return NoRevueMessage.Text;
    }
}
