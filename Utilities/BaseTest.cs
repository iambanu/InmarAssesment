using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlowFramework.Utilities;
using System.Reflection;
using TechTalk.SpecFlow.Infrastructure;
using TechTalk.SpecFlow;
using System.IO;
using SpecFlowProjectFramework.Configurations;

namespace SpecFlowFramework.Utilities
{
    [Binding]
    public class BaseTest
    {
        private readonly GlobalSettings _settings;
        private readonly ISpecFlowOutputHelper _outputHelper;

        public BaseTest(GlobalSettings settings, ScenarioContext scenarioContext, FeatureContext featureContext, ISpecFlowOutputHelper outputHelper)
        {
            _settings = settings;
            _outputHelper = outputHelper;
            _settings.Scenario = scenarioContext;
            _settings.Feature = featureContext;
            SeleniumExtensions.OutputHelper = outputHelper;
        }

        [BeforeScenario]
        public void SetupWebDriver()
        {
            _settings.WebDriver = _settings.WebDriver ?? InitializeWebDriver();
        }

        [AfterScenario]
        public void TearDownWebDriver()
        {
            try
            {
                AttachTestResults();
            }
            catch { }

            _settings.WebDriver?.Quit();
        }

        private static string GetSolutionPath()
        {
            string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return Directory.GetParent(assemblyPath).Parent.Parent.FullName;
        }

        private IWebDriver InitializeWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            string driverPath = Path.Combine(GetSolutionPath(), "Executables", "chromedriver.exe");
            chromeOptions.AddArgument("--no-sandbox");

            var driver = new ChromeDriver(driverPath, chromeOptions);
            driver.Manage().Window.Maximize();
            return driver;
        }

        private void AttachTestResults()
        {
            var testContext = TestContext.CurrentContext;
            string outcome = testContext.Result.Outcome.Status.ToString();
            TestContextHelper.AttachResultsToTest(_settings.WebDriver, _outputHelper, testContext, outcome);
        }
    }
}
