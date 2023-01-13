using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Start");

        FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\eug1n1\scoop\apps\GeckoDriver\current", "geckodriver.exe");
        service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

        FirefoxOptions firefoxOptions = new FirefoxOptions();
        firefoxOptions.AddArgument("--profile");
        firefoxOptions.AddArgument("C:\\Users\\eug1n1\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\e6ntxksp.default-release\\");

        IWebDriver driver = new FirefoxDriver(service, firefoxOptions);
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        driver.Navigate().GoToUrl("https://www.adidas.com/us");

        //var cookieButton = wait.Until(condition => condition.FindElements(By.ClassName("glass-gdpr-default-consent-accept-button")));
        //if (cookieButton.Count > 0)
        //{
        //    cookieButton[0].Click();
        //}

        IWebElement searchForm = wait.Until(condition => condition.FindElement(By.Name("q")));

        searchForm.SendKeys("superstar");
        searchForm.Submit();

        //var modalCloseButton = wait.Until(condition => condition.FindElements(By.ClassName("gl-modal__close")));
        //Thread.Sleep(3000);
        //if (modalCloseButton.Count > 0)
        //{
        //    modalCloseButton[0].Click();
        //}

        Thread.Sleep(5000);

        var products = wait.Until(condition => condition.FindElement(By.XPath("/html/body/div[2]/div/div[1]/div[1]/div/div/div[3]/div/div[3]/div/div/div[2]/div[1]/div/div[48]")));

        Console.WriteLine($"products: {products.Text}");

        products.FindElement(By.TagName("a")).Click();

        driver.Quit();
        Thread.Sleep(10000);
    }
}