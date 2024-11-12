using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject.StepDefinitions
{
    [Binding]
    public class WhenSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private readonly HttpClient _client;

        public WhenSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _client = new HttpClient();
            SetDefaultHeaders();
        }

        private void SetDefaultHeaders()
        {
            string token = ConfigHelper.GetSetting("BearerToken");
            string userAgent = ConfigHelper.GetSetting("UserAgent");

            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            _client.DefaultRequestHeaders.UserAgent.ParseAdd(userAgent);
        }

        [When(@"I make a POST request to the ""(.*)""")]
        public async Task WhenIMakeAPostRequestToThe(string endpoint)
        {
            string url = ConfigHelper.GetUrl(endpoint);
            string jsonPayload = _scenarioContext["JsonPayload"].ToString();
            StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync(url, content);
            _scenarioContext["Response"] = response;
        }

        [When(@"I make a GET request to the ""(.*)""")]
        public async Task WhenIMakeAGetRequestToThe(string endpoint)
        {
            string url = ConfigHelper.GetUrl(endpoint);
            HttpResponseMessage response = await _client.GetAsync(url);
            _scenarioContext["Response"] = response;
        }

        [When(@"I make an UPDATE request to the ""(.*)""")]
        public async Task WhenIMakeAnUpdateRequestToThe(string endpoint)
        {
            string url = ConfigHelper.GetUrl(endpoint);
            string jsonPayload = _scenarioContext["JsonPayload"].ToString();
            StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PatchAsync(url, content);
            _scenarioContext["Response"] = response;
        }

        [When(@"I make a DELETE request to the ""(.*)""")]
        public async Task WhenIMakeADeleteRequestToThe(string endpoint)
        {
            string url = ConfigHelper.GetUrl(endpoint);
            HttpResponseMessage response = await _client.DeleteAsync(url);
            _scenarioContext["Response"] = response;
        }

    }
}
