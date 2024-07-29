using OpenQA.Selenium;

namespace _02_StudentsRegistryPOM.Pages;

public class AddStudentPage : BasePage
{
    public AddStudentPage(IWebDriver driver) : base(driver)
    {
    }

    public override string PageUrl => base.PageUrl + "/add-student";

    public IWebElement ErrorMsg => driver.FindElement(By.XPath("//body/div"));
    public IWebElement FieldName => driver.FindElement(By.XPath("//div//input[@id='name']"));
    public IWebElement FieldEmail => driver.FindElement(By.XPath("//div//input[@id='email']"));
    public IWebElement ButtonAdd => driver.FindElement(By.XPath("//button[text()='Add']"));

    public void AddStudent(string name, string email)
    {
        this.FieldName.SendKeys(name);
        this.FieldEmail.SendKeys(email);
        this.ButtonAdd.Click();
    }

    public string GetErrorMsg()
    {
        return ErrorMsg.Text;
    }
}
