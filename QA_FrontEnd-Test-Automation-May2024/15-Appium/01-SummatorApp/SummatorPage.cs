using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace _01_SummatorApp;

public class SummatorPage
{
    private readonly AndroidDriver _driver;
    AppiumElement Num1 => _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText1"));
    AppiumElement Num2 => _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editText2"));
    AppiumElement CalcButton => _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/buttonCalcSum"));
    AppiumElement Result => _driver.FindElement(MobileBy.Id("com.example.androidappsummator:id/editTextSum"));

    public SummatorPage(AndroidDriver driver)
    {
        this._driver = driver;
    }

    public string Calculate(string number1, string number2)
    {
        ClearFields();

        Num1.SendKeys(number1);
        Num2.SendKeys(number2);
        CalcButton.Click();

        return Result.Text;
    }

    public void ClearFields()
    {
        Num1.Clear();
        Num2.Clear();
    }
}
