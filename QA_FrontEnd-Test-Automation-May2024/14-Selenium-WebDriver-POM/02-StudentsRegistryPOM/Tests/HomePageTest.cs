using _02_StudentsRegistryPOM.Pages;

namespace _02_StudentsRegistryPOM.Tests;

public class HomePageTest : BaseTest
{
    [Test]
    public void Test_HomePage_Content()
    {
        var homePage = new HomePage(driver);
        homePage.OpenPage();

        Assert.Multiple(() =>
        {
            Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
            Assert.That(homePage.GetPageHeadingText(), Is.EqualTo("Students Registry"));
            Assert.That(homePage.GetStudentsCount(), Is.GreaterThan(0));
        });
        
        Console.WriteLine("Students count: " + homePage.GetStudentsCount());
    }

    [Test]
    public void Test_HomePage_Links()
    {
        var homePage = new HomePage(driver);

        homePage.OpenPage();
        homePage.LinkHomePage.Click();
        Assert.That(new HomePage(driver).IsPageOpen(), Is.True);
        Console.WriteLine("HomePage is opened");

        homePage.OpenPage();
        homePage.LinkViewStudentsPage.Click();
        Assert.That(new ViewStudentsPage(driver).IsPageOpen(), Is.True);
        Console.WriteLine("ViewStudentsPage is opened");

        homePage.OpenPage();
        homePage.LinkAddStudentsPage.Click();
        Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
        Console.WriteLine("AddStudentsPage is opened");
    }
}
