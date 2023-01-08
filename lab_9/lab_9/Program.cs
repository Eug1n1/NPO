using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

Console.WriteLine("Start");

FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\eug1n1\scoop\apps\GeckoDriver\current", "geckodriver.exe"); 
service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

IWebDriver driver = new FirefoxDriver(service);

driver.Navigate().GoToUrl("https://www.adidas.com/us");

var cookieButton = driver.FindElements(By.ClassName("glass-gdpr-default-consent-accept-button"));
if (cookieButton.Count > 0)
{
    cookieButton[0].Click();
}

IWebElement searchForm = driver.FindElement(By.Name("q"));
searchForm.SendKeys("superstar");
searchForm.Submit();

Thread.Sleep(5000);

var modalCloseButton = driver.FindElements(By.ClassName("gl-modal__overlay"));
if (modalCloseButton.Count > 0)
{
    modalCloseButton[0].Click();
}

var products = driver.FindElements(By.ClassName("glass-product-card"));
Console.WriteLine($"products: {products.Count()}");

products[0].FindElement(By.TagName("a")).Click();