using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using lab_11.Pages;
using System.Diagnostics;
using lab_11.Driver;
using lab_11_12.Steps;

namespace lab_11
{
    public class Tests
    {

        Steps steps = new Steps();

        [SetUp]
        public void Setup()
        {
            steps.InitBrowser();

            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        public void SearchProduct()
        {
            string searchString = "superstar";

            steps.SearchProduct(searchString);
            Assert.That(steps.GetPageTitle().ToLower().Contains(searchString));
        }

        [Test]
        public void AddToFavorites()
        {
            string url = "https://www.adidas.com/us/superstar-shoes/FV3284.html";
            string searchWord = "superstar";

            Assert.That(steps.AddToFavorites(url).Where(x => x.Contains(searchWord)).Count() > 0);
        }

        [Test]
        public void RemoveFromFavorites()
        {
            //FavoritesPage favoritesPage = new FavoritesPage(driver);
            //favoritesPage.GoToPage();
            //int countBeforeRemove = favoritesPage.GetFavoritesTitles().Count();
            //favoritesPage.RemoveFromFavorites();

            //int countAfterRemove = favoritesPage.GetFavoritesTitles().Count();

            //Trace.WriteLine($"countBeforeRemove: {countBeforeRemove}");
            //Trace.WriteLine($"countAfterRemove: {countAfterRemove}");

            int countBeforeRemove = steps.RemoveOneFavorite();

            int countAfterRemove = steps.CountFavorites();

            Assert.That(countAfterRemove == countBeforeRemove - 1);
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
            Trace.Flush();
        }
    }
}