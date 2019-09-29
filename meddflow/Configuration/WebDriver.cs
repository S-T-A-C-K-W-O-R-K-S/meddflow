using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

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
                    webdriver = new FirefoxDriver(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\");
                    webdriver.Manage().Window.Maximize();
                    return webdriver;
                case "chrome":
                    webdriver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\");
                    webdriver.Manage().Window.Maximize();
                    return webdriver;
                default:
                    throw new Exception("IWebDriver Uninitialized");
            }
        }

        public static void TerminateDriver(IWebDriver webdriver)
        {
            webdriver.Close();
            webdriver.Quit();
        }
    }
}
