using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11.Pages
{
    public class FavoritesPage
    {
        private string testUrl = "https://www.adidas.com/us/wishlists";

        private IWebDriver driver;
        private WebDriverWait wait;

        public FavoritesPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            PageFactory.InitElements(driver, this);
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public IEnumerable<string> GetFavoritesTitles()
        {
            Thread.Sleep(5000);
            var elements = wait.Until(condition => condition.FindElements(By.XPath("//div[contains(@class, 'wishlist-card')]//p[@class='glass-product-card__title']")));

            return elements.Select(x => x.Text);
        }

        public void RemoveFromFavorites()
        {
            wait.Until(condition => condition.FindElement(By.XPath("//div[contains(@class, 'wishlist-card')]//div[@class='glass-product-card__wishlist']/button"))).Click();
            Thread.Sleep(5000);
        }
    }
}
