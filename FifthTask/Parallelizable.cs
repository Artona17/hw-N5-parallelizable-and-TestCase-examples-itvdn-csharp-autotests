using OpenQA.Selenium.Chrome;

namespace SecondTask
{
    [Author("Ludmila")]
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Tests
    {
        /// <summary>
        /// Method for setting up a Selenium Chrome WebDriver in our parallel executing tests.
        /// </summary>
        public IWebDriver SetUp()
        {
            return new ChromeDriver()
            {
                Url = "https://www.saucedemo.com/"
            };
        }

        /// <summary>
        /// Method for quitting our Selenium Chrome WebDriver in our parallel executing tests.
        /// </summary>
        public void TearDown(IWebDriver Driver)
        {
            Driver.Quit();
        }

        /// <summary>
        /// Test that checks that if we have empty <param name="username"></param> then a specific error message is displayed.
        /// Using [TestCase] with params and parallel executing of tests.
        /// </summary>
        [TestCase("")]
        public void LoginField_LoginFieldIsEmpty_LoginEmptyErrorMessageIsShowing(string username)
        {
            IWebDriver driver = SetUp();
            string loginErrorMessage = "Epic sadface: Username is required";

            IWebElement loginTxt = driver.FindElement(By.Id("user-name"));

            loginTxt.SendKeys(username);
            loginTxt.SendKeys(Keys.Enter);

            IWebElement loginError = driver.FindElement(By.CssSelector("#login_button_container > div > form > div.error-message-container.error > h3"));

            Assert.That(loginError.Text == loginErrorMessage);

            TearDown(driver);
        }

        /// <summary>
        /// Test that checks that if we have an actual <param name="username"></param> and empty <param name="password"></param>
        /// then a specific error message is displayed.
        /// Using [TestCase] with params and parallel executing of tests.
        /// </summary>
        [TestCase("standard_user", "")]

        public void PasswordField_PasswordFieldIsEmpty_PasswordEmptyErrorMessageIsShowing(string username, string password)
        {
            IWebDriver driver = SetUp();

            string passwordErrorMessage = "Epic sadface: Password is required";

            IWebElement loginTxt = driver.FindElement(By.Id("user-name"));
            IWebElement passwordTxt = driver.FindElement(By.Id("password"));

            loginTxt.SendKeys(username);
            passwordTxt.SendKeys(password);
            loginTxt.SendKeys(Keys.Enter);

            IWebElement passwordError = driver.FindElement(By.CssSelector("#login_button_container > div > form > div.error-message-container.error > h3"));

            Assert.That(passwordError.Text == passwordErrorMessage);
            TearDown(driver);
        }
    }
}
