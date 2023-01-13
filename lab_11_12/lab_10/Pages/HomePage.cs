using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_11.Pages
{
    public class HomePage
    {

        string testUrl = "https://www.adidas.com/us";

        private IWebDriver driver;
        private WebDriverWait wait;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement searchForm;

        public void GoToPage()
        {
            driver.Navigate().GoToUrl(testUrl);
        }

        public string getPageTitle()
        {
            return driver.Title;
        }

        public SearchPage testSearch(string input_search)
        {
            searchForm.SendKeys(input_search);
            searchForm.Submit();

            return new SearchPage(driver);
        }

    }
}
