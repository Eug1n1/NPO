using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;

namespace lab_11.Driver
{
    public class DriverSingleton
    {
        private static IWebDriver? driver;

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\Users\eug1n1\scoop\apps\GeckoDriver\current", "geckodriver.exe");
                service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";

                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArgument("--profile");
                firefoxOptions.AddArgument("C:\\Users\\eug1n1\\AppData\\Roaming\\Mozilla\\Firefox\\Profiles\\e6ntxksp.default-release\\");

                driver = new FirefoxDriver(service, firefoxOptions);

                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                //driver.Manage().Window.Maximize();
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver?.Quit();
            driver = null;
        }
    }
}
