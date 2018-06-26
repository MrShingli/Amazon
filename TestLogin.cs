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

        
        /*
        [Test]
        [Order(8)]
        public void UpisUBazu()
        {
            Thread.Sleep(2000);
            IWebElement kategorije = browser.FindElement(By.CssSelector("#nav-link-shopall span.nav-line-2"));
            kategorije.Click();
            IWebElement podKategorije = browser.FindElement(By.LinkText("See Fire TV Family"));
            podKategorije.Click();

            //IWebElement proizvodZaBazu = browser.FindElement(By.CssSelector("#anonCarousel1 ol"));
            //IWebElement[] proizvodZaBazuNiz = proizvodZaBazu.FindElements(By.TagName("li")).ToArray();

            MySqlConnection konekcija = new MySqlConnection("Server=127.0.0.1;Database=automatsko;Uid=root;Pwd=;");
            konekcija.Open();

            // pisanje upita
            MySqlCommand upit = new MySqlCommand("SELECT * FROM amazon", konekcija);

            // izvrsavanje upita
            MySqlDataReader citac = upit.ExecuteReader();

            int brojacRedova = 0; // broji redove iz baze

            bool podudaranjeSaBazom = true;

            // prolazak kroz redove dobijene iz baze
            while (citac.Read())
            {
                // jedan red iz baze
                string nazivBaza = citac["Naziv"].ToString();
                string cenaBaza = citac["Cena"].ToString();


                IWebElement proizvodiZaDB = browser.FindElement(By.CssSelector("#anonCarousel1 ol"));
                //niz
                IWebElement[] proizvodiZaDBNiz = proizvodiZaDB.FindElements(By.TagName("li")).ToArray();
                IWebElement proizvodPoredjenje = proizvodiZaDBNiz[brojacRedova];

                string nazivPoredjenje = proizvodPoredjenje.FindElement(By.CssSelector("div.acs_product-title a span")).Text;

                string cenaPoredjenje = proizvodPoredjenje.FindElement(By.CssSelector("div.acs_product-price span")).Text.Trim();

                // Poredimo tek kada prebacimo oba u mala slova
                if (nazivBaza.ToLower() == nazivPoredjenje.ToLower())
                {
                    Console.WriteLine("Proizvod: " + nazivPoredjenje + " - " + nazivBaza + " je pronadjen u bazi!!");

                    if (cenaBaza == cenaPoredjenje)
                    {
                        Console.WriteLine("Cena proizvoda je ista kao u bazi!!");
                    }
                    else
                    {
                        Console.WriteLine("Cena proizvoda NIJE ista kao u bazi!!");
                        podudaranjeSaBazom = false;
                        break; // Prekidamo petlju, ne prolazi dalje kroz redove
                    }
                }
                else
                {
                    Console.WriteLine("Proizvod: " + nazivPoredjenje + " - " + nazivBaza + " NIJE pronadjen u bazi!!");
                    podudaranjeSaBazom = false;
                    break; // Prekidamo petlju, ne prolazi dalje kroz redove
                }

                brojacRedova++; // idemo na sledeci red
            }


            // Proveravamo da li je popudaranje proslo
            Assert.IsTrue(podudaranjeSaBazom, "Proizvodi se NE podudaraju sa onima u bazi podataka!");

        }
        */




    }
}
