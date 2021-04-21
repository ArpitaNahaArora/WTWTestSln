using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using AventStack.ExtentReports;
using WTWTest.ComponentHelper;
using WTWTest.Configuration;
using AventStack.ExtentReports.Gherkin.Model;
using WTWTest.TestExecutionHelper;

namespace WTWTest.GeneralHook
{
    [Binding]
    public sealed class GeneralHook
    {
        private readonly ScenarioContext _scenarioContext;
        private static AventStack.ExtentReports.ExtentReports _extent;
        private static ExtentTest _featureName;
        private static ExtentTest _scenario, _step;

        private static readonly AppConfigReader Config = new AppConfigReader();
        public GeneralHook(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            var path = GenericHelper.CreateFolder("ResultsReport");
            path = path + @"\index.html";
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(path);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            _extent = new AventStack.ExtentReports.ExtentReports();
            _extent.AddSystemInfo("The tests are running on: ", Config.GetConfiguration().GetSection("Browser")["BrowserType"] + " Version: " + ChromeDriverVersionHelper.GetChromeBrowserVersion());
            _extent.AttachReporter(htmlReporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context)
        {
            _featureName = _extent.CreateTest(context.FeatureInfo.Title).AssignCategory(context.FeatureInfo.Title);            
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _scenario = _featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            var browserType = Config.GetConfiguration().GetSection("Browser")["BrowserType"];
            switch (browserType)
            {
                case "Chrome":
                    ObjectRepository.Driver = BaseClass.BaseClass.GetChromeDriver();
                    break;                
                default:
                    throw new DriverServiceNotFoundException("Driver not found" + browserType);
            }
        }

        [BeforeStep]
        public void BeforeStep()
        {
            _step = _scenario;
        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {       

            if (context.TestError == null)
            {
                _step.Log(Status.Pass, "<U><h4 style='color: orange'>" + context.StepContext.StepInfo.StepDefinitionType + "</h4></U> ::   " + context.StepContext.StepInfo.Text);

                if (context.StepContext.Keys.Count > 0)
                {
                    foreach (var result in context.StepContext)
                    {
                        _step.Log(Status.Info, result.Value.ToString());
                    }
                }

                if (context.StepContext.StepInfo.Text.Contains("displayed in output"))
                {
                    var listOfResults = context.Get<IList<string>>("ResultTitles");
                    _step.Log(Status.Info, "----------------------------------List Of Search Titles-------------------------------");
                    foreach (var item in listOfResults)
                    {
                        _step.Log(Status.Info, item);
                    }
                    _step.Log(Status.Info, "------------------------------------------------------------------------------------");
                    var path = GenericHelper.TakeScreenshot("ResultTitles");
                    _scenario.AddScreenCaptureFromPath(path);
                }
            }
            else if (context.TestError != null)
            {
                _step.Log(Status.Fail, "<U><h4 style='color: orange'>" + context.StepContext.StepInfo.StepDefinitionType + "</h4></U> ::   " + context.StepContext.StepInfo.Text);
                _step.Log(Status.Info, context.TestError.Message);
                var path = GenericHelper.TakeScreenshot(context.ScenarioInfo.Title);
                _scenario.AddScreenCaptureFromPath(path);
            }               
        }

        [AfterScenario]
        public void AfterScenario()
        {
            ObjectRepository.Driver.Close();
            ObjectRepository.Driver.Quit();            
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            _extent.Flush();
        }
    }
}
