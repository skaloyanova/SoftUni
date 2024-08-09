using OpenQA.Selenium;
using System;

namespace IdeaCenter.Pages;

public class ViewIdeaPage : BasePage
{
    private readonly By ideaTitle = By.XPath("//h1[@class='mb-0 h4']");
    private readonly By ideaDescription = By.XPath("//p[@class='offset-lg-3 col-lg-6']");

    public ViewIdeaPage(IWebDriver driver) : base(driver)
    {
    }

    public bool IsPageOpen()
    {
        return driver.Url.Contains("/Ideas/Read");
    }

    public string GetIdeaTitle()
    {
        return FindElement(ideaTitle).Text;
    }

    public string GetIdeaDescription()
    {
        return FindElement(ideaDescription).Text;
    }
}
