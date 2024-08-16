using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace MovieCatalog.Pages;

public class WatchedMoviesPage : BasePage
{
    protected override string PageUrl => base.PageUrl + "/Catalog/Watched";

    protected ReadOnlyCollection<IWebElement> MoviesOnCurrentPageList => FindElements(By.XPath("//div[@class='col-lg-4']"));
    protected ReadOnlyCollection<IWebElement> PagesList => FindElements(By.XPath("//ul[@class='pagination']//a"));
    private By MovieTitle => By.XPath(".//h2");

    public WatchedMoviesPage(IWebDriver driver) : base(driver)
    {
    }

    public IWebElement GetLastWatchedMovie()
    {
        PagesList.Last().Click();

        return MoviesOnCurrentPageList.LastOrDefault();
    }

    public string GetMovieTitle(IWebElement movie)
    {
        return movie.FindElement(MovieTitle).Text;
    }
}
