using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace DSMVCCodedUITest
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }
        
        [TestInitialize]
        public void Initialize()
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            BrowserWindow.CurrentBrowser = "IE";
            BrowserWindow.Launch(new System.Uri("http://dszczutkowski-001-site1.ctempurl.com/"));
            Console.WriteLine("Initializing the test");
        }

        [TestMethod]
        public void LoginLogoutUITest()
        {
            this.UIMap.LoginTest();
            this.UIMap.AssertLogin();
            this.UIMap.LogoutTest();
            this.UIMap.AssertLogout();
        }

        [TestMethod]
        public void OrderUITest()
        {

            this.UIMap.OrderTest();

        }

        [TestMethod]
        public void MealsUITest()
        {

            this.UIMap.TestMeal();

        }

        [TestMethod]
        public void ContactUITest()
        {
            this.UIMap.ContactTest();
            this.UIMap.AssertGithubAndMail();

        }

        [TestMethod]
        public void ButtonsUITest()
        {

            this.UIMap.ButtonTest();

        }

        [TestCleanup]
        public void Cleanup()
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
