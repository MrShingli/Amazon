using MySql.Data.MySqlClient;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon
{
    [TestFixture]
    [Order(1)]
    class TestLogin : ChromeOpen
    {
        


        public TestLogin()
        {
            browser.Manage().Window.Maximize();
            browser.Url = "https://www.amazon.com/"; 

        }

        [Test]
        [Order(1)]
        public void Login()
        {
            IWebElement signIn = browser.FindElement(By.Id("nav-link-accountList"));
            signIn.Click();
            IWebElement enterEmail = browser.FindElement(By.Name("email"));
            enterEmail.SendKeys(data.Email);
            IWebElement Continue = browser.FindElement(By.Id("continue"));
            Continue.Click();
            IWebElement enterPass = browser.FindElement(By.Name("password"));
            enterPass.SendKeys(data.Password);
            IWebElement Submit = browser.FindElement(By.Id("signInSubmit"));
            Submit.Click();

            Assert.Pass("User logged in");
        }


    }
}
