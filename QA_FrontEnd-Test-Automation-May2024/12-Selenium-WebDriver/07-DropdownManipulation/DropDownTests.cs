using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DropdownManipulation;

public class DropDownTests
{
    private IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }

    [Test]
    public void DropDown()
    {
        string targetDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..", @"..", @".."));
        string path = targetDir + "/manufacturer.txt";

        if (File.Exists(path)) File.Delete(path);


        SelectElement dropdown = new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select[@name='manufacturers_id']")));
        
        IList <IWebElement> options = dropdown.Options;

        List<string> manufacturerNames = [];

        foreach (var option in options)
        {
            manufacturerNames.Add(option.Text);
        }

        manufacturerNames.RemoveAt(0);      // removing "Please Select" option

        foreach (var mnfc in manufacturerNames)
        {
            Console.WriteLine(mnfc);
            dropdown.SelectByText(mnfc);
            dropdown = new SelectElement(driver.FindElement(By.XPath("//form[@name='manufacturers']//select[@name='manufacturers_id']")));

            if (driver.PageSource.Contains("There are no products available in this category."))
            {
                File.AppendAllText(path, $"The manufacturer {mnfc} has no products\n\n");
            } else
            {
                File.AppendAllText(path, $"The manufacturer {mnfc} products are listed--\n");

                IWebElement table = driver.FindElement(By.XPath("//table[@class='productListingData']"));
                ReadOnlyCollection<IWebElement> tableRows = table.FindElements(By.XPath(".//tbody/tr"));

                foreach (var tr in tableRows)
                {
                     File.AppendAllText(path, tr.Text + "\n");  
                }

                File.AppendAllText(path, "\n");
            }
        }

        Assert.That(File.Exists(path), Is.True, "File does not exist");
        Assert.That(new FileInfo(path).Length > 0, Is.True, "File is empty");
    }
}