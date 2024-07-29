using _02_StudentsRegistryPOM.Pages;

namespace _02_StudentsRegistryPOM.Tests;

public class ViewStudentsTest : BaseTest
{
    [Test]
    public void Test_ViewStudentsPage_Content()
    {
        var viewStudentsPage = new ViewStudentsPage(driver);

        viewStudentsPage.OpenPage();

        Assert.Multiple(() =>
        {
            Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewStudentsPage.GetPageHeadingText(), Is.EqualTo("Registered Students"));
        });

        string[] students = viewStudentsPage.GetStudentsList();
        Assert.That(students.Length, Is.GreaterThan(0));
        Console.WriteLine("Students records: " + viewStudentsPage.GetStudentsList().Length);

        foreach (var student in students)
        {
            Assert.That(student.Contains("("));
            Assert.That(student.LastIndexOf(")") == student.Length - 1);
        }
    }

    [Test]
    public void Test_ViewStudentsPage_Links()
    {
        var viewStudentsPage = new ViewStudentsPage(driver);

        viewStudentsPage.OpenPage();
        viewStudentsPage.LinkHomePage.Click();
        Assert.That(new HomePage(driver).IsPageOpen(), Is.True);

        viewStudentsPage.OpenPage();
        viewStudentsPage.LinkViewStudentsPage.Click();
        Assert.That(new ViewStudentsPage(driver).IsPageOpen(), Is.True);

        viewStudentsPage.OpenPage();
        viewStudentsPage.LinkAddStudentsPage.Click();
        Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
    }
}
