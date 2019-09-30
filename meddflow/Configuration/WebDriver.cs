using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Reflection;

namespace meddflow
{
    public class WebDriver
    {
        public static IWebDriver InitializeDriver(string browser)
        {
            IWebDriver webdriver;

            switch (browser)
            {
                case "firefox":
                    FirefoxOptions optionsGecko = new FirefoxOptions();
                    optionsGecko.
                        AddArguments("--window-size=1920,1080");
                    webdriver = new FirefoxDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), optionsGecko);
                    return webdriver;
                case "chrome":
                    ChromeOptions optionsChrome = new ChromeOptions();
                    optionsChrome.
                        AddArguments("--window-size=1920,1080");
                    webdriver = new ChromeDriver(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), optionsChrome);
                    return webdriver;
                default:
                    throw new Exception("IWebDriver Uninitialized");
            }
        }

        public static WebDriverWait Wait(IWebDriver driver, int milliseconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromMilliseconds(milliseconds));
        }

        public static void TerminateDriver(IWebDriver webdriver)
        {
            webdriver.Close();
            webdriver.Quit();
        }
    }
}
