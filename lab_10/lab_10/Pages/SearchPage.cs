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
    public class SearchPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        int timeout = 10000;

        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);

            wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
        }

        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[1]/div[1]/div/div/div[3]/div/div[3]/div/div/div[2]/div[1]/div/div[1]")]
        private IWebElement searchElement;

        public ProductPage clickSearchResult()
        {
            wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div/div/div[3]/div/div[3]/div/div/div[2]/div[1]/div/div[48]"))).Click();

            return new ProductPage(driver);
        }
    }
}
