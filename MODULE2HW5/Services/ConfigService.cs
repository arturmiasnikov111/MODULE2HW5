using System;
using System.IO;
using Newtonsoft.Json;

namespace MODULE2HW5.Services
{
    public class ConfigService
    {
        public ConfigService()
        {
            Config = JsonConvert.DeserializeObject<Config>(File.ReadAllText("/Users/arturmiasnykov/RiderProjects/MODULE2HW5/MODULE2HW5/config.json"));
        }

        public Config Config { get; set; }
    }
}