using OpenQA.Selenium;

namespace _01_Calculator_POM;

public class SumNumbersPage
{
    private readonly IWebDriver driver;

    public SumNumbersPage(IWebDriver driver)
    {
        this.driver = driver;

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    private const string PAGE_URL = "https://1b1c893a-540d-4781-9efb-093bd2a7d65a-00-13n52f4gd851r.worf.replit.dev/";

    public IWebElement FieldNumber1 => driver.FindElement(By.XPath("//input[@name='number1']"));
    public IWebElement FieldNumber2 => driver.FindElement(By.XPath("//input[@name='number2']"));
    public IWebElement CalculateButton => driver.FindElement(By.XPath("//input[@id='calcButton']"));
    public IWebElement ResetButton => driver.FindElement(By.XPath("//input[@id='resetButton']"));
    public IWebElement Result => driver.FindElement(By.XPath("//div[@id='result']"));

    public void OpenPage()
    {
        driver.Navigate().GoToUrl(PAGE_URL);
    }

    public void ResetForm()
    {
        ResetButton.Click();
    }

    public bool IsFormEmpty()
    {
        return FieldNumber1.GetAttribute("value") == "" && FieldNumber2.GetAttribute("value") == "" && Result.Text == "";
    }

    public string SumNumbers(string num1, string num2)
    {
        FieldNumber1.SendKeys(num1);
        FieldNumber2.SendKeys(num2);
        CalculateButton.Click();
        return Result.Text;
    }
}
