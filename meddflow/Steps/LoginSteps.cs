using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace meddflow
{
    [Binding]
    public class LoginSteps
    {
        readonly IWebDriver driver = WebDriver.InitializeDriver("firefox");

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            string URL = "https://system10.meddbase.com/em.aspx/?p=Login/Password&direct=true";
            driver.Navigate().GoToUrl(URL);
        }

        [When(@"I enter my username and password")]
        public void WhenIEnterMyUsernameAndPassword(Table table)
        {
            IWebElement usernameInput = driver.FindElement(By.CssSelector("div#LoginUsernameTextbox > div > input[name='MasterPage:UserName']"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("div#LoginPasswordTextbox > div > input[name='MasterPage:_ctl16']"));

            var (username, password) = table.CreateInstance<(string username, string password)>();

            usernameInput.SendKeys(username);
            passwordInput.SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.CssSelector("div#LoginButtonContainer > input[type='submit']"));

            loginButton.Click();
        }

        [Then(@"I should be authenticated to the application home page")]
        public void ThenIShouldBeAuthenticatedToTheApplicationHomePage()
        {
            Assert.AreEqual("Start Page", driver.Title);

            WebDriver.TerminateDriver(driver);
        }
    }
}
