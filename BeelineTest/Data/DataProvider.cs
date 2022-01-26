using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BeelineTest.Data
{
    public class DataProvider
    {
        private static readonly string _nameOfConfigJsonFile = "Config.json";
        private static ConfigData configData;

        public static ConfigData GetConfigData()
        {
            string objectJsonFile = File.ReadAllText(_nameOfConfigJsonFile);
            configData = JsonConvert.DeserializeObject<ConfigData>(objectJsonFile);
            return configData;
        }
    }
}
