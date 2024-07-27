using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace _06_WorkingWithWebTables;

public class WebTableTests
{
    private ChromeDriver driver;

    [SetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("http://practice.bpbonline.com/");
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
        driver.Dispose();
    }


    [Test]
    public void WebTable()
    {
        // locate table
        IWebElement productTable = driver.FindElement(By.XPath("//div[@class='contentText']//table"));

        // locate table rows
        ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody//tr"));

        // create csv file (currentDir -> \bin\Debug\net8.0)
        string currentDir = System.IO.Directory.GetCurrentDirectory();
        string targetDir = Path.GetFullPath(Path.Combine(currentDir, @"..", @"..", @".."));
        string path = targetDir + "/productInformation.csv";

        // if csv file already exists - delete it
        if (File.Exists(path))
        {
            File.Delete(path);
        }

        foreach (var tr in tableRows)
        {
            ReadOnlyCollection<IWebElement> tableData = tr.FindElements(By.XPath(".//td"));
            foreach (var td in tableData)
            {
                string[] productData = td.Text.Split("\n");
                string productToAddInCsv = productData[0].Trim() + "," + productData[1].Trim() + "\n";

                // Add product to csv file
                File.AppendAllText(path, productToAddInCsv);
            }
        }

        // assert that file exists and is not empty
        Assert.That(File.Exists(path), Is.True, "CSV file is not created");
        Assert.That(new FileInfo(path).Length > 0, "CSV file is empty");
    }
}