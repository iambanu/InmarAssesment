using OpenQA.Selenium;
using SpecFlowProjectFramework.Configurations;
using TechTalk.SpecFlow;

namespace SpecFlowFramework.PageObjects
{
    [Binding]
    public abstract class BasePage
    {
        private readonly GlobalSettings _settings;
        public IWebDriver driver => _settings.WebDriver;
        public GlobalSettings Settings => _settings;

        public BasePage(GlobalSettings settings)
        {
            _settings = settings;
        }
    }
}
