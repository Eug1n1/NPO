using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using lab_10.Pages;
using System.Diagnostics;

namespace lab_10
{
    public class Tests
    {

        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\eug1n1\scoop\apps\GeckoDriver\current", "geckodriver.exe");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

            FirefoxOptions firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArgument("--profile");
            firefoxOptions.AddArgument("C:\\Users\\eug1n1\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\e6ntxksp.default-release\\");

            driver = new FirefoxDriver(service, firefoxOptions);

            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        public void SearchProduct()
        {
            string searchString = "superstar";

            HomePage home_page = new HomePage(driver);
            home_page.GoToPage();
            ProductPage productPage = home_page.testSearch(searchString).clickSearchResult();

            Assert.That(productPage.GetPageTitle().ToLower().Contains(searchString));
        }

        [Test]
        public void AddToFavorites()
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.GoToPage();
            FavoritesPage favoritesPage = productPage.AddToFavorites();

            Thread.Sleep(5000);

            Assert.That(favoritesPage.GetFavoritesTitles()
                .Select(x => x.ToLower())
                .Where(x => x.Contains("superstar"))
                .Count() > 0);
        }

        [Test]
        public void test()
        {
            Debug.WriteLine("This is Debug.WriteLine");
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            Trace.Flush();
        }
    }
}