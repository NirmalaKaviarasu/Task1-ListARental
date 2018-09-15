using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace ListARental.Pages
{
    class ListARentalPage
    {

        private readonly IWebDriver _driver;

        private WebDriverWait _Wait;

                public ListARentalPage(IWebDriver driver)
        {
            _driver = driver;
            _Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(_driver, this);
        }


        [FindsBy(How = How.CssSelector, Using = "input.search")]
        [CacheLookup]
        public IWebElement SelectProp { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[3]/div[1]/input[1]")]
        [CacheLookup]
        public IWebElement Title { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[3]/div[2]/textarea")]
        [CacheLookup]
        public IWebElement Description { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[3]/div[1]/input[2]")]
        [CacheLookup]
        public IWebElement MovingCost { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[4]/div[1]/input")]
        [CacheLookup]
        public IWebElement TargetRent { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[5]/div[1]/input")]
        [CacheLookup]
        public IWebElement AvailableDate { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[6]/div[1]/input")]
        [CacheLookup]
        public IWebElement OccupantsCount { get; set; }

        [FindsBy(How = How.Id, Using = "file-upload")]
        [CacheLookup]
        public IWebElement UploadPhoto { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/form/fieldset/div[8]/div/button[1]")]
        [CacheLookup]
        public IWebElement Save { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div/div[2]/a[2]")]
        [CacheLookup]
        public IWebElement PropForRent { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[5]/div/div[5]/a[1]")]
        [CacheLookup]
        public IWebElement Skip { get; set; }

        [FindsBy(How = How.Id, Using = "SearchBox")]
        [CacheLookup]
        public IWebElement Searchbox { get; set; }

        [FindsBy(How = How.Id, Using = "SearchBox")]
        [CacheLookup]
        public IWebElement SearchProp { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#mainPage > div > fieldset > div.ui.three.stackable.cards > div:nth-child(1) > div:nth-child(2) > a")]
        [CacheLookup]
        public IWebElement Clickrentprop { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='main-content']/div/div[3]/h2")]
        [CacheLookup]
        public IWebElement ListARenatalPage { get; set; }


        public void Enter_Value_ListARentalPage()
        {

            // var SelectElement = new SelectElement(SelectProp);
            // SelectElement.SelectByIndex(1);

            Actions actions = new Actions(_driver);
            actions.MoveToElement(SelectProp);
            actions.Click();
            actions.SendKeys("1222 High Street, Taita, Lower Hutt, 5011");
            actions.Build().Perform();
            System.Threading.Thread.Sleep(200);


            Title.SendKeys("TestTitleNewToRent");
            Description.SendKeys("Description To Test");
            MovingCost.SendKeys("2000");
            TargetRent.SendKeys("200");
            AvailableDate.Click();
            AvailableDate.Clear();
            AvailableDate.SendKeys("16/07/2019");
            System.Threading.Thread.Sleep(250);

            OccupantsCount.SendKeys("2");
            UploadPhoto.SendKeys(@"C:\Users\Mallik\Documents\Key-Project\property-connect-home.jpg");
            System.Threading.Thread.Sleep(150);

            Save.Click();
            _Wait.Until(condition: ExpectedConditions.ElementExists(By.Id("SearchBox")));

            // IAlert alert = _driver.SwitchTo().Alert();
            // alert.Accept();

            // System.Threading.Thread.Sleep(50);

        }

        public void PropforRent()
        {


            PropForRent.Click();
            _Wait.Until(ExpectedConditions.ElementExists(By.XPath("/html/body/div[5]/div/div[5]/a[1]")));
            Skip.Click();
            _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='SearchBox']")));
           
            Clickrentprop.Click();

                      
        }

        public void takescreenshot()
        {
            _Wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='rentalPropertyDetails']/div[1]/div/div[2]/button/span[1]")));

            Screenshot ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(@"C:\Users\Mallik\source\repos\ListARental\ListARental\Screenshot\RentedProperty.jpg");

        }
    }
}
