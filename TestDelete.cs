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
    [Order(3)]
    class TestDelete : ChromeOpen
    {
        [Test]
        [Order(6)]
        public void DeleteFunction()
        {
            IWebElement delete = browser.FindElement(By.CssSelector("input[value='Delete']"));
            delete.Click();
            Thread.Sleep(3000);
            IWebElement totalItem = browser.FindElement(By.Id("sc-subtotal-label-activecart"));
            string totalItemText = totalItem.Text.Replace(" items): $0.00", "").Replace("Subtotal (", "");

            if (totalItemText == "0")
            {
                Assert.Pass("Deleting successfully, the cart is empty");
            }
            else
            {
                Assert.Fail("Deleting failed");
            }
        }

        
    }
}
