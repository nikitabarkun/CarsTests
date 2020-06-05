using System;
using System.IO;
using Newtonsoft.Json;

namespace TestFramework
{
    public class TestConfiguration
    {
        private string configPath;

        public TestConfiguration(string configPath)
        {
            this.configPath = configPath;
        }

        public string GetParameter(string param)
        {
            dynamic settings = JsonConvert.DeserializeObject(File.ReadAllText(configPath));

            try
            {
                Logger.GetInstance().LogLine($"Reading parameter '{param}' from config file...");
                return settings[param];
            }
            catch (Exception)
            {
                Logger.GetInstance().LogLine($"ERROR: Cannot read parameter '{param}' from config ({configPath})!");
                throw new Exception($"ERROR: Cannot read parameter '{param}' from config ({configPath})!");
            }
        }
    }
}