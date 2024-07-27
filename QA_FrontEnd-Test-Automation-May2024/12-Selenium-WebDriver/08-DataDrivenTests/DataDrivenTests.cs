using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _08_DataDrivenTests
{
    public class DataDrivenTests
    {
        ChromeDriver driver;
        IWebElement firstNumTextbox;
        IWebElement secondNumTextbox;
        SelectElement operationDropdown;
        IWebElement calculateButton;
        IWebElement resetButton;
        IWebElement resultDiv;


        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/");
            firstNumTextbox = driver.FindElement(By.Id("number1"));
            operationDropdown = new SelectElement(driver.FindElement(By.Id("operation")));
            secondNumTextbox = driver.FindElement(By.Id("number2"));
            calculateButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            resultDiv = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [TestCase("2", "+", "2", "Result: 4")]
        [TestCase("2.9", "+", "2.01", "Result: 4.91")]
        [TestCase("-2", "+", "3", "Result: 1")]
        [TestCase("-2", "+", "-3", "Result: -5")]
        [TestCase("-2", "+", "0", "Result: -2")]
        [TestCase("0", "+", "0", "Result: 0")]
        [TestCase("0", "+", "Infinity", "Result: Infinity")]
        [TestCase("Infinity", "+", "Infinity", "Result: Infinity")]
        [TestCase("a", "+", "2", "Result: invalid input")]
        [TestCase("3", "+", "a", "Result: invalid input")]
        [TestCase("", "+", "a", "Result: invalid input")]

        [TestCase("2", "-", "2", "Result: 0")]
        [TestCase("2.9", "-", "2.01", "Result: 0.89")]
        [TestCase("-2", "-", "3", "Result: -5")]
        [TestCase("-2", "-", "-3", "Result: 1")]
        [TestCase("-2", "-", "0", "Result: -2")]
        [TestCase("0", "-", "0", "Result: 0")]
        [TestCase("0", "-", "Infinity", "Result: -Infinity")]
        [TestCase("Infinity", "-", "Infinity", "Result: invalid calculation")]
        [TestCase("a", "-", "2", "Result: invalid input")]
        [TestCase("3", "-", "a", "Result: invalid input")]
        [TestCase("3", "-", "", "Result: invalid input")]

        [TestCase("2", "*", "3", "Result: 6")]
        [TestCase("2.9", "*", "2.01", "Result: 5.829")]
        [TestCase("-2", "*", "5", "Result: -10")]
        [TestCase("-2", "*", "-3", "Result: 6")]
        [TestCase("-2", "*", "0", "Result: 0")]
        [TestCase("0", "*", "0", "Result: 0")]
        [TestCase("Infinity", "*", "0", "Result: invalid calculation")]
        [TestCase("Infinity", "*", "4", "Result: Infinity")]
        [TestCase("Infinity", "*", "Infinity", "Result: Infinity")]
        [TestCase("a", "*", "2", "Result: invalid input")]
        [TestCase("3", "*", "a", "Result: invalid input")]
        [TestCase("", "*", "a", "Result: invalid input")]

        [TestCase("25", "/", "100", "Result: 0.25")]
        [TestCase("25", "/", "2.5", "Result: 10")]
        [TestCase("2.22", "/", "1.11", "Result: 2")]
        [TestCase("-20", "/", "5", "Result: -4")]
        [TestCase("-27", "/", "-3", "Result: 9")]
        [TestCase("0", "/", "5", "Result: 0")]
        [TestCase("-2", "/", "0", "Result: -Infinity")]
        [TestCase("5", "/", "0", "Result: Infinity")]
        [TestCase("Infinity", "/", "Infinity", "Result: invalid calculation")]
        [TestCase("Infinity", "/", "1", "Result: Infinity")]
        [TestCase("0", "/", "0", "Result: invalid calculation")]
        [TestCase("a", "/", "2", "Result: invalid input")]
        [TestCase("3", "/", "a", "Result: invalid input")]
        [TestCase("3", "/", "", "Result: invalid input")]
                
        public void CalculatorTests(string num1, string op, string num2, string expectedResult)
        {
            // reset form
            resetButton.Click();

            // enter data in the fields and click Calculate
            firstNumTextbox.SendKeys(num1);
            operationDropdown.SelectByValue(op);
            secondNumTextbox.SendKeys(num2);
           
            calculateButton.Click();

            // assert result
            Assert.That(resultDiv.Text, Is.EqualTo(expectedResult));
        }
    }
}