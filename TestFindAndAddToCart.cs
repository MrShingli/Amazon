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
    [Order(2)]
    class TestFindAndAddToCart : ChromeOpen
    {
        public string productName = "fire tv with 4k ultra hd + hd antenna";
        public string productPrice;
        public string productAmount;
        public string category = "See Fire TV Family";

        [Test]
        [Order(2)]
        public void Category()
        {
            Thread.Sleep(2000);
            IWebElement departments = browser.FindElement(By.CssSelector("#nav-link-shopall span.nav-line-2"));
            departments.Click();
            
            IWebElement Category = browser.FindElement(By.LinkText(category));
            Category.Click();
            Assert.Pass("You have entered the category"); 
        }

        [Test]
        [Order(3)]
        public void ChoosingProduct()
        {
            IWebElement productList = browser.FindElement(By.CssSelector("ol[role='list']"));
            
            IWebElement[] productListArray = productList.FindElements(By.TagName("li")).ToArray();

            for (int i = 0; i < productListArray.Count(); i++)
            {
                IWebElement aLink = productListArray[i].FindElement(By.CssSelector("div.acs_product-title a span"));
                
                if (aLink.Text.ToLower() == productName)
                {
                    aLink.Click();
                    Assert.Pass("The product is selected");
                    break;
                }
            }
        }

        [Test]
        [Order(4)]
        public void ProductData()
        {
            IWebElement name = browser.FindElement(By.Id("productTitle"));
            productName = name.Text;

            IWebElement price = browser.FindElement(By.Id("priceblock_ourprice"));
            productPrice = price.Text;
            IWebElement addToCart = browser.FindElement(By.Id("add-to-cart-button"));
            addToCart.Click();
            Thread.Sleep(2000);
            IWebElement addToCartContinue = browser.FindElement(By.CssSelector("input[aria-labelledby='a-autoid-19-announce']"));
            addToCartContinue.Click();

            Assert.Pass("You chose the product " + productName + " - " + productPrice);
            
        }

        [Test]
        [Order(5)]
        public void Cart()
        {
            Thread.Sleep(2000);
            IWebElement Cart = browser.FindElement(By.Id("nav-cart-count"));
            Cart.Click();
            IWebElement productNameInCart = browser.FindElement(By.CssSelector("span.sc-product-title"));
            IWebElement productPriceInCart = browser.FindElement(By.CssSelector("#sc-subtotal-amount-activecart span"));

            if (productName == productNameInCart.Text && productPriceInCart.Text == productPrice)
            {
                Assert.Pass("Cart works " + productNameInCart.Text + " - " + productPriceInCart.Text);
            }
            else
            {
                Assert.Fail("Data does not match");
            }

        }

        



    }
}
