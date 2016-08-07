using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;

namespace DSMVCSeleniumTest
{
    [TestClass]
    public class seleniumTest
    {
        private IWebDriver driver;
        private IWebElement element;

        [TestInitialize]
        public void Initialize()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://dszczutkowski-001-site1.ctempurl.com/");
        }

        public void Login()
        {   
            /*s
            element = driver.FindElement(By.XPath("//a[@href='/Account/Login']"));
            element.Click();
            */
            element = driver.FindElement(By.Id("loginLink"));
            element.Click();
            element = driver.FindElement(By.Id("Email"));
            element.Click();
            element.SendKeys("abc@gmail.com");
            element = driver.FindElement(By.Id("Password"));
            element.Click();
            element.SendKeys("Asd!23");
            element = driver.FindElement(By.XPath("//input[@value='Zaloguj']"));
            element.Click();
        }

        [TestMethod]
        public void LoginTest()
        {
            Login();
            element = driver.FindElement(By.XPath("//a[@href='/Manage']"));
            string s = element.Text;
            Assert.AreEqual(s, "Witaj abc@gmail.com!");
        }

        [TestMethod]
        public void LogoutTest()
        {
            Login();
            element = driver.FindElement(By.PartialLinkText("Log"));
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            element = driver.FindElement(By.Id("loginLink"));
            string s = element.Text;
            Assert.AreNotEqual(s, "Witaj abc@gmail.com!");
        }

        [TestMethod]
        public void ButtonTest()
        {
            element = driver.FindElement(By.XPath("//a[@href='../Posilki/Nazwy']"));
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            element = driver.FindElement(By.PartialLinkText("cej"));
            element.Click();
            Assert.IsNotNull(element);
        }

        [TestMethod]
        public void CreateTest()
        {
            Login();
            element = driver.FindElement(By.XPath("//a[@href='/Posilki']"));
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            element = driver.FindElement(By.XPath("//a[@href='/Meals/Create']"));
            element.Click();
            element = driver.FindElement(By.Id("Name"));
            element.Click();
            element.SendKeys("test Name");
            element = driver.FindElement(By.Id("Price"));
            element.Click();
            element.SendKeys("3.94");
            element = driver.FindElement(By.XPath("//input[@value='Create']"));
            element.Click();
            element = driver.FindElement(By.XPath("//table/tbody/tr[last()]"));
            Assert.IsTrue(element.Text.Contains("test Name $3.94"));

            
        }

        [TestMethod]
        public void UpdateTest()
        {
            Login();
            element = driver.FindElement(By.XPath("//a[@href='/Posilki']"));
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            element = driver.FindElement(By.XPath("//table/tbody/tr[last()]/td[3]/a[1]"));
            element.Click();
            element = driver.FindElement(By.Id("Name"));
            element.Click();
            element.Clear();
            element.SendKeys("edit Name");
            element = driver.FindElement(By.Id("Price"));
            element.Click();
            element.Clear();
            element.SendKeys("12.34");
            element = driver.FindElement(By.XPath("//input[@value='Save']"));
            element.Click();
            element = driver.FindElement(By.ClassName("table"));
            Assert.IsTrue(element.Text.Contains("edit Name $12.34"));

        }

        [TestMethod]
        public void DeleteTest()
        {
            Login();
            element = driver.FindElement(By.XPath("//a[@href='/Posilki']"));
            element.Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            element = driver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[3]"));
            element.Click();
            element = driver.FindElement(By.XPath("//input[@value='Delete']"));
            element.Click();
            element = driver.FindElement(By.XPath("//table"));
            Assert.IsFalse(element.Text.Contains("test 12.34"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}