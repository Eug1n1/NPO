using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.Pages
{
    public class ProductPage
    {
        private string testUrl = "https://www.adidas.com/us/superstar-shoes/FV3284.html";

        private IWebDriver driver;
        private WebDriverWait wait;

        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testUrl);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public FavoritesPage AddToFavorites()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div/div/div[2]/div[2]/div[2]/section/div[3]/div"))).Click();
            wait.Until(condition => condition.FindElement(By.XPath("//div[contains(@class, 'gl-wishlist-icon')]"))).Click();

            return new FavoritesPage(driver);
        }
    }
}
