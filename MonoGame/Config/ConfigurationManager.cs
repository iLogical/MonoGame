using System;
using System.Collections.Generic;
using System.IO;
using MonoGame.Config.Configurations;
using Newtonsoft.Json;
namespace MonoGame.Config
{
    public interface IConfigurationManager
    {
        T Load<T>();
    }

    public class ConfigurationManager : IConfigurationManager
    {
        private readonly Dictionary<Type,string> _settingFileLocations;

        public ConfigurationManager()
        {
            _settingFileLocations = new Dictionary<Type, string>
            {
                [typeof(DisplaySettingsConfiguration)] = ".//Config//DisplaySettings.json",
                [typeof(KeyBindingConfiguration)] = ".//Config//KeyBindings.json"
            };
        }
        
        public T Load<T>()
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_settingFileLocations[typeof(T)]));
        }
    }

}