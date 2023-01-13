using lab_11.Driver;
using lab_11.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11_12.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = DriverSingleton.GetInstance();
        }

        public void CloseBrowser()
        {
            DriverSingleton.CloseBrowser();
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void SearchProduct(string searchString)
        {
            HomePage home_page = new HomePage(driver);
            home_page.GoToPage();
            ProductPage productPage = home_page.testSearch(searchString).clickSearchResult();
        }

        public IEnumerable<string> AddToFavorites(string productUrl)
        {
            driver.Navigate().GoToUrl(productUrl);

            ProductPage productPage = new ProductPage(driver);
            FavoritesPage favoritesPage = productPage.AddToFavorites();

            Thread.Sleep(5000);

            return favoritesPage.GetFavoritesTitles()
                .Select(x => x.ToLower());
        }

        public int RemoveOneFavorite()
        {
            FavoritesPage favoritesPage = new FavoritesPage(driver);
            favoritesPage.GoToPage();

            int before = favoritesPage.GetFavoritesTitles().Count();

            favoritesPage.RemoveFromFavorites();

            return before;
        }

        public int CountFavorites()
        {
            FavoritesPage favoritesPage = new FavoritesPage(driver);
            favoritesPage.GoToPage();
            
            return favoritesPage.GetFavoritesTitles().Count();
        }

        //public void LoginGithub(string username, string password)
        //{
        //    Pages.LoginPage loginPage = new Pages.LoginPage(driver);
        //    loginPage.OpenPage();
        //    loginPage.Login(username, password);
        //}

        //public string GetLoggedInUserName()
        //{
        //    Pages.LoginPage loginPage = new Pages.LoginPage(driver);
        //    return loginPage.GetLoggedInUserName();
        //}

        //public void CreateNewRepository(string repositoryName, string repositoryDescription)
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(driver);
        //    mainPage.ClickOnCreateNewRepositoryButton();
        //    Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    createNewRepositoryPage.CreateNewRepository(repositoryName, repositoryDescription);
        //}

        //public string GenerateRandomRepositoryNameWithCharLength(int howManyChars)
        //{
        //    string repositoryNamePrefix = "testRepo_";
        //    return string.Concat(repositoryNamePrefix, Utils.RandomGenerator.GetRandomString(howManyChars));
        //}

        //public bool CurrentRepositoryIsEmpty()
        //{
        //    Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    return createNewRepositoryPage.IsCurrentRepositoryEmpty();
        //}

        //public string GetCurrentRepositoryName()
        //{
        //    Pages.CreateNewRepositoryPage createNewRepositoryPage = new Pages.CreateNewRepositoryPage(driver);
        //    return createNewRepositoryPage.GetCurrentRepositoryName();
        //}
    }
}
