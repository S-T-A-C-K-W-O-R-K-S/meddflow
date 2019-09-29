using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace meddflow
{
    [Binding]
    public class LoginSteps
    {
        readonly IWebDriver driver = WebDriver.InitializeDriver("chrome");

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            string URL = "http://testing-ground.scraping.pro/login";
            driver.Navigate().GoToUrl(URL);
        }

        [When(@"I enter my username and password")]
        public void WhenIEnterMyUsernameAndPassword(Table table)
        {
            IWebElement usernameInput = driver.FindElement(By.Id("usr"));
            IWebElement passwordInput = driver.FindElement(By.Id("pwd"));

            var (username, password) = table.CreateInstance<(string username, string password)>();
            // Working Effectively with SpecFlow Tables: https://joebuschmann.com/working-effectively-with-specflow-tables/

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.CssSelector("input[type='submit']"));

            loginButton.Click();
        }

        [Then(@"I should be authenticated to the application home page")]
        public void ThenIShouldBeAuthenticatedToTheApplicationHomePage()
        {
            IWebElement loggedIn = driver.FindElement(By.CssSelector("h3.error"));

            Assert.AreEqual("ACCESS DENIED!", loggedIn.Text);

            WebDriver.TerminateDriver(driver);
        }
    }
}

// "ScenarioContext.StepIsPending()" can also be used to remove the warning that "ScenarioContext.Current.Pending()" generates
