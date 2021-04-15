using System.IO;
using Newtonsoft.Json;
namespace MonoGame.Config
{
    public interface IConfigurationManager
    {
        T Load<T>(string configName);
    }

    public class ConfigurationManager : IConfigurationManager
    {
        public T Load<T>(string configName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText($".//Config//{configName}.json"));
        }
    }

}