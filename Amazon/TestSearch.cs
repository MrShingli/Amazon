using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    [TestFixture]
    [Order(4)]
    class TestSearch : ChromeOpen
    {
        [Test]
        [Order(7)]
        public void Pretraga()
        {
            IWebElement searchTextBox = browser.FindElement(By.Id("twotabsearchtextbox"));
            string searchText = "Fire TV";
            searchTextBox.SendKeys(searchText);
            IWebElement searchButton = browser.FindElement(By.CssSelector("div.nav-search-submit input"));
            searchButton.Click();

            IWebElement result = browser.FindElement(By.Id("s-results-list-atf"));
            //niz
            IWebElement[] resultArray = result.FindElements(By.TagName("li")).ToArray();

            for (int i = 0; i < resultArray.Count(); i++)
            {
                IWebElement naslov = resultArray[i].FindElement(By.CssSelector("div div:nth-child(2) div div:nth-child(2) div:first-child div:first-child a h2"));

                if (naslov.Text.Contains(searchText))
                {
                    Assert.Pass("Search works");
                    break;
                }
                else
                {
                    Assert.Fail("Search does not work");
                }
            }
        }
    }
}
