using System;
using Microsoft.Xna.Framework.Input;
namespace MonoGame.Input
{
    public class KeyPressedArgs : EventArgs
    {
        public Keys Key { get; }
        public bool NewlyPressed { get; }

        public KeyPressedArgs(Keys key, bool newlyPressed = false)
        {
            Key = key;
            NewlyPressed = newlyPressed;
        }
    }
}