using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _02_StudentsRegistryPOM.Pages;

public class ViewStudentsPage : BasePage
{
    public ViewStudentsPage(IWebDriver driver) : base(driver)
    {
    }

    public override string PageUrl => base.PageUrl + "/students";

    protected ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.XPath("//ul//li"));

    public string[] GetStudentsList()
    {
        var studentsList = this.ListItemsStudents.Select(e => e.Text).ToArray();
        return studentsList;
    }


}
