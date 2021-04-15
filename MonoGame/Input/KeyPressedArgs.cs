using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
namespace MonoGame.Input
{
    public class KeyPressedArgs : EventArgs
    {
        public Dictionary<Keys, bool> PressedKeys { get; }

        public KeyPressedArgs()
        {
            PressedKeys = new Dictionary<Keys, bool>();
        }

        public void AddPressedKey(Keys key, bool newlyPressed = false)
        {
            PressedKeys.Add(key, newlyPressed);
        }
    }
}