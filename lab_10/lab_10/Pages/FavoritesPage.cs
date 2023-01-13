using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.Pages
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
            var elements = wait.Until(condition => condition.FindElements(By.XPath("//div[@class='wishlist-card___3MX7z']//p[@class='glass-product-card__title']")));

            return elements.Select(x => x.Text);
        }

        public void AddToFavorites()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div/div/div[2]/div[2]/div[2]/section/div[3]/div"))).Click();
        }
    }
}
