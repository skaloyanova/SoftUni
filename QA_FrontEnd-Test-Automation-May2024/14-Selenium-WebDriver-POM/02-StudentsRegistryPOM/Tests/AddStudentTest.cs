using _02_StudentsRegistryPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_StudentsRegistryPOM.Tests;

public class AddStudentTest : BaseTest
{
    [Test]
    public void Test_AddStudentPage_Content()
    {
        var addStudentPage = new AddStudentPage(driver);
        addStudentPage.OpenPage();

        Assert.Multiple(() =>
        {
            Assert.That(addStudentPage.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(addStudentPage.GetPageHeadingText(), Is.EqualTo("Register New Student"));
            Assert.That(addStudentPage.FieldName.Displayed);
            Assert.That(addStudentPage.FieldEmail.Displayed);
            Assert.That(addStudentPage.ButtonAdd.Displayed);
            Assert.That(addStudentPage.FieldName.Text == "");
            Assert.That(addStudentPage.FieldEmail.Text == "");
            Assert.That(addStudentPage.ButtonAdd.Text == "Add");
        });
    }

    [Test]
    public void Test_AddStudentPage_Links()
    {
        var addStudentPage = new AddStudentPage(driver);

        addStudentPage.OpenPage();
        addStudentPage.LinkHomePage.Click();
        Assert.That(new HomePage(driver).IsPageOpen(), Is.True);

        addStudentPage.OpenPage();
        addStudentPage.LinkViewStudentsPage.Click();
        Assert.That(new ViewStudentsPage(driver).IsPageOpen(), Is.True);

        addStudentPage.OpenPage();
        addStudentPage.LinkAddStudentsPage.Click();
        Assert.That(new AddStudentPage(driver).IsPageOpen(), Is.True);
    }

    [Test]
    public void Test_AddStudentPage_AddValidStudent()
    {
        var addStudentPage = new AddStudentPage(driver);
        addStudentPage.OpenPage();

        string name = "Student " + DateTime.Now.Ticks;
        string email = "mail" + DateTime.Now.Ticks + "@example.com";
        addStudentPage.AddStudent(name, email);

        var viewStudentPage = new ViewStudentsPage(driver);
        Assert.That(viewStudentPage.IsPageOpen(), "View Student page is not opened");
        Assert.That(viewStudentPage.GetStudentsList().Contains($"{name} ({email})"), "Student is missing");
    }

    [Test]
    public void Test_AddStudentPage_AddInvalidStudent()
    {
        var addStudentPage = new AddStudentPage(driver);
        addStudentPage.OpenPage();

        string name = "";
        string email = "mail" + DateTime.Now.Ticks + "@example.com";
        addStudentPage.AddStudent(name, email);

        Assert.That(addStudentPage.IsPageOpen());
        Assert.That(addStudentPage.GetErrorMsg(), Is.EqualTo("Cannot add student. Name and email fields are required!"));

        addStudentPage.LinkViewStudentsPage.Click();
        var viewStudentPage = new ViewStudentsPage(driver);
        Assert.That(viewStudentPage.IsPageOpen(), "View Student page is not opened");
        Assert.That(viewStudentPage.GetStudentsList().Contains($"{name} ({email})"), Is.False, "Student is missing");
    }
}
