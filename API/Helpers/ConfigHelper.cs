using System.Configuration;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SpecFlowProject
{
    public static class ConfigHelper
    {
        private static readonly JObject Config;
        private static readonly JObject Payload;

        static ConfigHelper()
        {
            string configPath = Path.Combine(Directory.GetCurrentDirectory(),"config.json");
            string configContent = File.ReadAllText(configPath);
            Config = JObject.Parse(configContent);
        }
        public static string GetUrl(string endpoint)
        {
            string baseUrl = Config["urls"]["BaseUrl"].ToString();
            string endpointPath = Config["urls"][endpoint].ToString();
            return $"{baseUrl}{endpointPath}";
        }

        public static string GetSetting(string key)
        {
            return Config[key].ToString();
        }
    }
}
