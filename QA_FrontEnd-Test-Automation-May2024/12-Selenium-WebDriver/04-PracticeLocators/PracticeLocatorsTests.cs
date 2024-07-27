using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _04_PracticeLocators
{
    public class PracticeLocatorsTests
    {
        private ChromeDriver _driver;
        private string _baseUrl = @"file:///D:/_Coding/SoftUni/QA_FrontEnd-Test-Automation-May2024/12-Selenium-WebDriver/04-PracticeLocators/SimpleForm/Locators.html";

        [OneTimeSetUp]
        public void Setup()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1200");
            _driver = new ChromeDriver(options);

            _driver.Navigate().GoToUrl(_baseUrl);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Test]
        public void LocateAndVerifyElements()
        {
            // Find the LastName by ID
            var lastName = _driver.FindElement(By.Id("lname"));

            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Vega"));

            // Find the Newsletter by Name
            var newsletterCheckbox = _driver.FindElement(By.Name("newsletter"));

            Assert.That(newsletterCheckbox.Selected, Is.False);

            // Find the Official Softuni Page by TagName
            var softuniPageLink1 = _driver.FindElement(By.TagName("a"));

            Assert.That(softuniPageLink1.Text, Is.EqualTo("Softuni Official Page"));

            // Find the information fields by ClassName
            var information = _driver.FindElement(By.ClassName("information"));
            string backgroundColor = information.GetCssValue("background-color");

            Assert.That(backgroundColor, Is.EqualTo("rgba(255, 255, 255, 1)"));

            // Find elements by Text Link Locators
            var softuniPageLink2 = _driver.FindElement(By.LinkText("Softuni Official Page"));
            var softuniPageLink3 = _driver.FindElement(By.PartialLinkText("Softuni"));
                        
            Assert.That(softuniPageLink2.GetAttribute("href"), Is.EqualTo("http://www.softuni.bg/"));
            Assert.That(softuniPageLink3.Text, Is.EqualTo("Softuni Official Page"));

            // prints
            Console.WriteLine("lastName: " + lastName.GetAttribute("value"));
            Console.WriteLine("newsletterCheckbox is checked: " + newsletterCheckbox.Selected);
            Console.WriteLine("softuniPageLink1: " + softuniPageLink1.Text);
            Console.WriteLine("softuniPageLink2 href: " + softuniPageLink2.GetAttribute("href"));
            Console.WriteLine("softuniPageLink3: " + softuniPageLink3.Text);
            Console.WriteLine("information backgroundColor: " + backgroundColor);
        }

        [Test]
        public void LocateAndVerifyElements_byCSSselectors()
        {
            // Locate the "First name" input field by ID and verify its value
            var firstNameById = _driver.FindElement(By.CssSelector("#fname"));
            Assert.That(firstNameById.GetAttribute("value"), Is.EqualTo("Vincent"));

            // Locate the "First name" input field by name attribute and verify its value
            var firstNameByAttribute = _driver.FindElement(By.CssSelector("input[name='fname']"));
            Assert.That(firstNameByAttribute.GetAttribute("value"), Is.EqualTo("Vincent"));

            // Locate the submit button by class name and verify its value attribute
            var submitBtn1 = _driver.FindElement(By.CssSelector(".button"));
            var submitBtn2 = _driver.FindElement(By.CssSelector("input[class=button]"));
            Assert.That(submitBtn1.GetAttribute("value"), Is.EqualTo("Submit"));
            Assert.That(submitBtn2.GetAttribute("value"), Is.EqualTo("Submit"));

            // Locate the "Phone Number" input field by CSS selector and verify it is displayed
            var phoneNumber1 = _driver.FindElement(By.CssSelector("div.additional-info > p > input[type=text]"));
            Assert.That(phoneNumber1.Displayed, Is.True);

            // Locate the "Phone Number" input field using a more specific CSS selector and verify it is displayed
            var phoneNumber2 = _driver.FindElement(By.CssSelector("form div.additional-info input[type = text]"));
            Assert.That(phoneNumber2.Displayed, Is.True);
        }

        [Test]
        public void LocateAndVerifyElements_byXPathLocators()
        {
            // Locate the male radio button using absolute XPath and verify its value attribute
            var maleRadioAbs = _driver.FindElement(By.XPath("/html/body/form/input[1]"));
            Assert.That(maleRadioAbs.GetAttribute("value"), Is.EqualTo("m"));

            // Locate the male radio button using relative XPath and verify its value attribute
            var maleRadioRel = _driver.FindElement(By.XPath("//input[@value = 'm']"));
            Assert.That(maleRadioRel.GetAttribute("value"), Is.EqualTo("m"));

            // Locate the last name input field using relative XPath and verify its value
            var lastNameAbs = _driver.FindElement(By.XPath("//input[@name = 'lname']"));
            Assert.That(lastNameAbs.GetAttribute("value"), Is.EqualTo("Vega"));

            // Locate the newsletter checkbox using relative XPath and verify its type attribute
            var lastNameRel = _driver.FindElement(By.XPath("//input[@name = 'newsletter']"));
            Assert.That(lastNameRel.GetAttribute("type"), Is.EqualTo("checkbox"));

            // Locate the submit button using relative XPath and verify its value attribute
            var submitBtn = _driver.FindElement(By.XPath("//input[@class = 'button']"));
            Assert.That(submitBtn.GetAttribute("value"), Is.EqualTo("Submit"));

            // Locate the phone number input field within additional info using relative XPath and verify it is displayed
            var phoneNumber = _driver.FindElement(By.XPath("//div[@class = 'additional-info']//input[@type = 'text']"));
            Assert.That(phoneNumber.Displayed, Is.True);
        }

        [Test]
        public void TestForm()
        {
            // Asserts the "Contact Form" title.
            var title = _driver.FindElement(By.TagName("h2"));
            Assert.That(title.Text, Is.EqualTo("Contact Form"));

            // Selects the male radio button and asserts its selection.
            var maleRadioButton = _driver.FindElement(By.CssSelector("input[value = m]"));
            Assert.That(maleRadioButton.Selected, Is.False);
            maleRadioButton.Click();
            Assert.That(maleRadioButton.Selected,Is.True);

            // Enters "Butch" as the first name and asserts the entered value.
            var firstName = _driver.FindElement(By.Id("fname"));
            firstName.Clear();
            firstName.SendKeys("Butch");
            Assert.That(firstName.GetAttribute("value"), Is.EqualTo("Butch"));

            // Enters "Coolidge" as the last name and asserts the entered value.
            var lastName = _driver.FindElement(By.Id("lname"));
            lastName.Clear();
            lastName.SendKeys("Coolidge");
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Coolidge"));

            // Asserts the presence of the "Additional Information" section.
            var additionaInfo = _driver.FindElement(By.TagName("h3"));
            Assert.That(additionaInfo.Text, Is.EqualTo("Additional Information"));

            // Enters "0888999777" as the phone number and asserts the entered value.
            var phoneNumber = _driver.FindElement(By.XPath("//div[@class = 'additional-info']//input[@type = 'text']"));
            phoneNumber.Clear();
            phoneNumber.SendKeys("0888999777");
            Assert.That(phoneNumber.GetAttribute("value"), Is.EqualTo("0888999777"));

            // Selects the newsletter checkbox and asserts its selection.
            var newsletter = _driver.FindElement(By.XPath("//input[@type = 'checkbox']"));
            Assert.That(newsletter.Selected, Is.False);
            newsletter.Click();
            Assert.That(newsletter.Selected, Is.True);

            // Clicks the submit button.
            var submitButton = _driver.FindElement(By.XPath("//input[@type = 'submit']"));
            submitButton.Click();

            // Asserts the "Thank You!" message on the next page.
            var thankYouMessage = _driver.FindElement(By.TagName("h1"));
            Assert.That(thankYouMessage.Text, Is.EqualTo("Thank You!"));
        }
    }
}