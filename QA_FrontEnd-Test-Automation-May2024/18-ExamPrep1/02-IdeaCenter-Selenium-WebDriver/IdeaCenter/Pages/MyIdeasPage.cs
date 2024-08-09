
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;

namespace IdeaCenter.Pages;

public class MyIdeasPage : BasePage
{
    private readonly By searchField = By.XPath("//input[@id='search-input']");
    private readonly By idea = By.XPath("//div[@class='card mb-4 box-shadow']");
    private readonly By ideaViewButton = By.XPath(".//a[text()='View']");
    private readonly By ideaEditButton = By.XPath(".//a[text()='Edit']");
    private readonly By ideaDeleteButton = By.XPath(".//a[text()='Delete']");
    private readonly By ideaDescriptionText = By.XPath(".//p[@class='card-text']");

    private string url = baseUrl + "/Ideas/MyIdeas";

    public MyIdeasPage(IWebDriver driver) : base(driver)
    {
    }

    public ReadOnlyCollection<IWebElement> GetIdeasList()
    {
        return FindElements(idea);
    }

    public void openPage()
    {
        driver.Navigate().GoToUrl(url);
    }

    public bool IsPageOpen()
    {
        return this.driver.Url == url;
    }

    public IWebElement GetIdeaByDescription(string description)
    {
        return GetIdeasList().FirstOrDefault(e => e.FindElement(ideaDescriptionText).Text == description);
    }

    public IWebElement GetLastCreatedIdea()
    {
        return GetIdeasList().LastOrDefault();
    }

    public string GetIdeaDescription(IWebElement idea) 
    {
        return idea.FindElement(ideaDescriptionText).Text;
    }

    public void ClickIdeaViewButton(IWebElement idea)
    {
        idea.FindElement(ideaViewButton).Click();
    }

    public void ClickIdeaEditButton(IWebElement idea)
    {
        idea.FindElement(ideaEditButton).Click();
    }

    public void ClickIdeaDeleteButton(IWebElement idea)
    {
        idea.FindElement(ideaDeleteButton).Click();
    }

}
