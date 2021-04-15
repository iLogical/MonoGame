using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoGame.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MonoGame.Config.Configurations
{
    public class KeyBindingConfiguration
    {
        public Dictionary<InputActionType, KeyBinding> Actions { get; set; }

        public class KeyBinding
        {
            [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
            public List<Keys> Primary { get; set; }
            [JsonProperty (ItemConverterType = typeof(StringEnumConverter))]
            public List<Keys> Secondary { get; set; }

            public KeyBinding()
            {
                Primary = new List<Keys>();
                Secondary = new List<Keys>();
            }
        }
    }
}