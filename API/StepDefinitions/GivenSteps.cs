using Newtonsoft.Json.Linq;
using System.IO;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class GivenSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public GivenSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I have a valid token")]
        public void GivenIHaveAValidToken()
        {
            string token = ConfigHelper.GetSetting("BearerToken");
            _scenarioContext["Token"] = token;
        }

        [Given(@"I have a JSON payload named ""(.*)""")]
        public void GivenIHaveAJsonPayloadNamed(string fileName)
        {
            string baseDirectory = Directory.GetCurrentDirectory();
            string jsonDirectory = Path.Combine(baseDirectory, "Json"); 
            string filePath = Path.Combine(jsonDirectory, $"{fileName}");

            if (File.Exists(filePath))
            {
                string jsonPayload = File.ReadAllText(filePath);
                _scenarioContext["JsonPayload"] = jsonPayload;
            }
            else
            {
                throw new FileNotFoundException($"The file '{fileName}.json' was not found in the 'Json' directory.");
            }
        }
    }
}
