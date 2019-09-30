using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace meddflow
{
    [Binding]
    public class LoginSteps
    {
        public IWebDriver driver = WebDriver.InitializeDriver("chrome");

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            string URL = "http://automationpractice.com/";
            driver.Navigate().GoToUrl(URL);
            driver.FindElement(By.CssSelector("a.login")).Click();

            WebDriver.Wait(driver, 5000).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("form#login_form")));
        }

        [When(@"I enter my email and password")]
        public void WhenIEnterMyEmailAndPassword(Table table)
        {
            IWebElement emailInput = driver.FindElement(By.CssSelector("input#email"));
            IWebElement passwordInput = driver.FindElement(By.CssSelector("input#passwd"));

            var (email, password) = table.CreateInstance<(string email, string password)>();

            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            IWebElement loginButton = driver.FindElement(By.CssSelector("button#SubmitLogin"));

            loginButton.Click();
        }

        [Then(@"I should be authenticated to the application home page")]
        public void ThenIShouldBeAuthenticatedToTheApplicationHomePage()
        {
            Assert.AreEqual("MY ACCOUNT - MY STORE", driver.Title.ToUpper());
        }

        [AfterScenario]
        public void TearDown()
        {
            WebDriver.TerminateDriver(driver);
        }
    }
}
