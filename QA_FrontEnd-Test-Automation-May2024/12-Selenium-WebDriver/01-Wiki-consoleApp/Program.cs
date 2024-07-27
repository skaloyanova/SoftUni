using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Initialize Selenium Web Driver <create Chrome browser instance>
WebDriver driver = new ChromeDriver();

// Open web site
driver.Url = "https://wikipedia.org";

// Print page title
Console.WriteLine("Wiki page title: " + driver.Title);

// Find search field
var searchField = driver.FindElement(By.Id("searchInput"));

// Type 'Quality Assurance' and press [Enter]
searchField.SendKeys("Quality Assurance" + Keys.Enter);

// Print page title of the new searched page
Console.WriteLine("Searched page title: " + driver.Title);

if(driver.Title == "Quality assurance - Wikipedia")
{
    Console.WriteLine("*** TEST PASS ***");
} else
{
    Console.WriteLine("*** TEST FAIL ***");
}

// Shut down Web Driver
driver.Quit();