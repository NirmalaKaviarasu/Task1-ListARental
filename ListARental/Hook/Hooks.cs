using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Gherkin;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;


namespace ListARental

{
    [Binding]
    public sealed class Hooks
    {
        public static IWebDriver driver;
        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports Extent = new ExtentReports();



        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\Mallik\source\repos\ListARental\ListARental\ExtentReport\ExtendReportForListARental.html");

            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TeardownReport()
        {
            Extent.Flush();

        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            //Get Titile of the Feature File
            feature = Extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);

            

        }

        [AfterStep]
        public static void InsertReportingSteps()
        {
            scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);

        }

        [BeforeScenario]
        public static void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://dev.property.community/Account/Login";

            //Get Scenario Title
            scenario = feature.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }



        [AfterScenario]
        public static void AfterScenario()
        {
            driver.Dispose();

        }


    }
}
