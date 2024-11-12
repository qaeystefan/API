using System.Net.Http;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class ThenSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public ThenSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Then(@"the response should be successful")]
        public void ThenTheResponseShouldBeSuccessful()
        {
            HttpResponseMessage response = (HttpResponseMessage)_scenarioContext["Response"];
            Assert.IsTrue(response.IsSuccessStatusCode, $"Request failed with status code: {response.StatusCode}");
        }
    }
}
