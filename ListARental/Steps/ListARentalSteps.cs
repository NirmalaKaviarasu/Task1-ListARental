using System;
using TechTalk.SpecFlow;
using ListARental.Pages;
using OpenQA.Selenium;

namespace ListARental.Steps
{
    [Binding]
    public class ListARentalSteps
    {
        
        [Given(@"Login as Property Owner")]
        public void GivenLoginAsPropertyOwner()
        {
            LoginPage lp = new LoginPage(Hooks.driver);
            lp.LoginToApp();

        }
        
        [Given(@"Navigate to OwnersPage and Select MyPropertyPage")]
        public void GivenNavigateToOwnersPageAndSelectMyPropertyPage()
        {
            MyPropertyPage mp = new MyPropertyPage(Hooks.driver);
            
            mp.NavigateToOWner();
            mp.NavigateToMyProperty();
        }
        
        [When(@"I Select List a Rental option")]
        public void WhenISelectListARentalOption()
        {
            MyPropertyPage mp = new MyPropertyPage(Hooks.driver);
            mp.ListARental();
        }
        
        [When(@"Enter Details in List Rental Property Page by selecting Property to Rent and Save")]
        public void WhenEnterDetailsInListRentalPropertyPageBySelectingPropertyToRentAndSave()
        {
            ListARentalPage lp = new ListARentalPage(Hooks.driver);
            lp.Enter_Value_ListARentalPage();
                    }
        
        [Then(@"Property should dispalyed on PropertiesForRent Page")]
        public void ThenPropertyShouldDispalyedOnPropertiesForRentPage()
        {
            ListARentalPage lp = new ListARentalPage(Hooks.driver);
            lp.PropforRent();
            lp.takescreenshot();

        }
    }
}
