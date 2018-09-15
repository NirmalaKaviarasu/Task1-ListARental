using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace ListARental.Pages
{
    class MyPropertyPage
    {
        private readonly IWebDriver _driver;

        private WebDriverWait _Wait;


        public MyPropertyPage(IWebDriver driver)
        {
            _driver = driver;
            _Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "body > div.ui.fixed.top.text.menu > div > div.right.menu > div:nth-child(2)")]
        [CacheLookup]
        public IWebElement Ownertab { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners']")]
        [CacheLookup]
        public IWebElement Myproperty { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners/Property/AddNewProperty']")]
        [CacheLookup]
        public IWebElement Addnewproperty { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/i")]
        [CacheLookup]
        public IWebElement Clickprop { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/div/div[5]")]
        [CacheLookup]
        public IWebElement Deleteoption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/div[1]/div/div[2]/div/div[2]/a[1]")]
        [CacheLookup]
        public IWebElement ListARentalButton { get; set; }


        public void NavigateToOWner()
        {
            _Wait.Until(condition: ExpectedConditions.ElementExists(By.CssSelector("div.ui.dropdown.item")));
            Ownertab.Click();

        }

        public void NavigateToMyProperty()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//a[@href='/PropertyOwners']")));
            Myproperty.Click();


        }

        public void ClickonAddnewproperty()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.CssSelector("a.ui.teal.button")));
            string Propertypagetitle = _driver.Title;
            Assert.AreEqual(Propertypagetitle, "Properties | Property Community");
            Addnewproperty.Click();

        }



        public void takescreenshot()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.Id("SearchBox")));

            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Mallik\Desktop\KeyProjectN\KeyProjectN\Screenshot\CreatedProperty.jpg");

        }


        public void Select_Prop_To_Delete()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.Id("SearchBox")));
            Clickprop.Click();
            System.Threading.Thread.Sleep(4000);
            Deleteoption.Click();

        }

        public void ListARental()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.Id("SearchBox")));
            ListARentalButton.Click();

        }
    }
}
