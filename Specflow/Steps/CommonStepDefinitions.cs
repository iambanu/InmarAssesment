using SpecFlowProjectFramework.Configurations;
using TechTalk.SpecFlow;

namespace SpecFlowFramework.StepDefinitions
{
    public abstract class CommonStepDefinitions : Steps
    {
        private GlobalSettings _settings;
        public GlobalSettings Settings => _settings;

        public CommonStepDefinitions(GlobalSettings settings)
        {
            _settings = settings;
        }
    }
}
