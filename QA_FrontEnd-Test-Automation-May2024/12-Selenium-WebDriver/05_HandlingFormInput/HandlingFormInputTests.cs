using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _05_HandlingFormInput;

public class HandlingFormInputTests
{
    private const string BASE_URL = "http://practice.bpbonline.com/";
    private ChromeDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl(BASE_URL);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void Handling_CreateAccount_Form()
    {
        // click 'My Account' button
        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100000);
        driver.FindElement(By.CssSelector("#tdb3 span.ui-button-text")).Click();

        var welcomeTitle = driver.FindElement(By.CssSelector("#bodyContent h1"));
        Assert.That(welcomeTitle.Text, Is.EqualTo("Welcome, Please Sign In"));

        // click 'Continue' button
        //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(100000);
        driver.FindElement(By.LinkText("Continue")).Click();

        var myAccountTitle = driver.FindElement(By.CssSelector("#bodyContent h1"));
        Assert.That(myAccountTitle.Text, Is.EqualTo("My Account Information"));

        // INPUT DATA
        string firstName = "Hali";
        string lastName = "Fax";
        string dateOfBirth = "02/28/1978";
        var rnd = new Random();
        int num = rnd.Next(1000, 9999);
        string email = $"user{num}@example.com";
        string companyName = "Some Company Name";
        string street = "Graf Ignatiev 1";
        string suburb = "Center";
        string postcode = "1000";
        string city = "Sofia City";
        string state = "Sofia";
        string phone = "0123456789";
        string password = "passWORD";

        // Select Gender - female
        var genderElement = driver.FindElement(By.XPath("//input[@type = 'radio'][@value = 'f']"));
        genderElement.Click();
        Assert.That(genderElement.GetAttribute("value"), Is.EqualTo("f"));

        // Enter First Name
        var firstnameElement = driver.FindElement(By.XPath("//td[@class = 'fieldValue']//input[@name = 'firstname']"));
        firstnameElement.SendKeys(firstName);
        Assert.That(firstnameElement.GetAttribute("value"), Is.EqualTo(firstName));

        // Enter Last Name
        var lastnameElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'lastname']"));
        lastnameElement.SendKeys(lastName);
        Assert.That(lastnameElement.GetAttribute("value"), Is.EqualTo(lastName));

        // Enter Date of Birth
        var dateOfBirthElement = driver.FindElement(By.Id("dob"));
        dateOfBirthElement.SendKeys(dateOfBirth);
        Assert.That(dateOfBirthElement.GetAttribute("value"), Is.EqualTo(dateOfBirth));

        // Enter Email Address
        var emailElement = driver.FindElement(By.XPath("//td[@class = 'fieldValue']//input[@name = 'email_address']"));
        emailElement.SendKeys(email);
        Assert.That(emailElement.GetAttribute("value"), Is.EqualTo(email));

        // Enter Company Name
        var companyNameElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'company']"));
        companyNameElement.SendKeys(companyName);
        Assert.That(companyNameElement.GetAttribute("value"), Is.EqualTo(companyName));

        // Enter Street Address
        var streetElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'street_address']"));
        streetElement.SendKeys(street);
        Assert.That(streetElement.GetAttribute("value"), Is.EqualTo(street));

        // Enter Suburb
        var suburbElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'suburb']"));
        suburbElement.SendKeys(suburb);
        Assert.That(suburbElement.GetAttribute("value"), Is.EqualTo(suburb));

        // Enter Postcode
        var postcodeElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'postcode']"));
        postcodeElement.SendKeys(postcode);
        Assert.That(postcodeElement.GetAttribute("value"), Is.EqualTo(postcode));

        // Enter City
        var cityElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'city']"));
        cityElement.SendKeys(city);
        Assert.That(cityElement.GetAttribute("value"), Is.EqualTo(city));

        // Enter State
        var stateElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'state']"));
        stateElement.SendKeys(state);
        Assert.That(stateElement.GetAttribute("value"), Is.EqualTo(state));

        // Select Country from dropdown (use SelectElement which is part of the OpenQA.Selenium.Support.UI namespace)
        var counrtyElement = driver.FindElement(By.XPath("//td[@class = 'fieldValue']//select[@name = 'country']"));
        SelectElement selectCountry = new SelectElement(counrtyElement);
        selectCountry.SelectByText("Bulgaria");
        Assert.That(selectCountry.SelectedOption.Text, Is.EqualTo("Bulgaria"));

        // Enter Telephone Number
        var phoneElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'telephone']"));
        phoneElement.SendKeys(phone);
        Assert.That(phoneElement.GetAttribute("value"), Is.EqualTo(phone));

        // Opt for Newsletter Subscription
        var newsletterElement = driver.FindElement(By.XPath("//input[@type = 'checkbox'][@name = 'newsletter']"));
        newsletterElement.Click();
        Assert.That(newsletterElement.Selected, Is.True);

        // Enter Password
        var passwordElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'password']"));
        passwordElement.SendKeys(password);
        Assert.That(passwordElement.GetAttribute("value"), Is.EqualTo(password));

        // Confirm Password
        var confirmPasswordElement = driver.FindElement(By.CssSelector(".fieldValue input[name = 'confirmation']"));
        confirmPasswordElement.SendKeys(password);
        Assert.That(confirmPasswordElement.GetAttribute("value"), Is.EqualTo(password));

        // Submit the form
        var continueButton = driver.FindElement(By.Id("tdb4"));
        continueButton.Click();

        // Assert Your Account Has Been Created Page
        Assert.That(driver.PageSource.Contains("Your Account Has Been Created!"), "Account creation failed");

        // click Log Off link
        driver.FindElement(By.Id("tdb4")).Click();
        Assert.That(driver.PageSource.Contains("You have been logged off your account"), "Uncucessfull Logout");

        // click Continue button
        driver.FindElement(By.Id("tdb4")).Click();
        Assert.That(driver.PageSource.Contains("Welcome to BPB Online"));

        Console.WriteLine($"User Account Created with email: {email}");

    }
}