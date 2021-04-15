using System.IO;
using Newtonsoft.Json;
namespace MonoGame.Config
{
    public class ConfigurationManager
    {
        public T Load<T>(string configName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($".//Config//{configName}.json"));
        }
    }

}