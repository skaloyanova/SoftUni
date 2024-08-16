using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace MovieCatalog.Pages;

public class AllMoviesPage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Catalog/All";

    protected ReadOnlyCollection<IWebElement> MoviesOnCurrentPageList => FindElements(By.XPath("//div[@class='col-lg-4']"));
    protected ReadOnlyCollection<IWebElement> PagesList => FindElements(By.XPath("//ul[@class='pagination']//a"));
    private By MovieTitle => By.XPath(".//h2");
    private By EditMovieButton => By.XPath(".//a[text()='Edit']");
    private By DeleteMovieButton => By.XPath(".//a[text()='Delete']");
    private By MarkMovieWatchedUnwatchedButton => By.XPath(".//a[@class='btn btn-info']");

    public AllMoviesPage(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement GetLastCreatedMovie()
    {
        PagesList.Last().Click();

        return MoviesOnCurrentPageList.LastOrDefault();
    }

    public string GetMovieTitle(IWebElement movie)
    {
        return movie.FindElement(MovieTitle).Text;
    }

    public void ClickEditButtonOnMovie(IWebElement movie)
    {
        movie.FindElement(EditMovieButton).Click();
    }

    public void ClickDeleteButtonOnMovie(IWebElement movie)
    {
        movie.FindElement(DeleteMovieButton).Click();
    }

    public void ClickMarkMovieAsWatched(IWebElement movie)
    {
        var button = movie.FindElement(MarkMovieWatchedUnwatchedButton);

        if (button.Text == "Mark as Watched")
        {
            button.Click();
        }
        else if (button.Text == "Mark as Unwatched")
        {
            Assert.Fail("Movie is already marked as watched");
        }
    }
}
