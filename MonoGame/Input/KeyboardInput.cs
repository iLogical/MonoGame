using System;
using Microsoft.Xna.Framework.Input;
namespace MonoGame.Input
{
    public class KeyboardInput
    {
        public event EventHandler<KeyPressedArgs> KeyPressed;
        private KeyboardState _state;
        private KeyboardState _oldState;
        public KeyboardInput()
        {
            _state = Keyboard.GetState();
        }

        public void RefreshState()
        {
            _oldState = _state;
            _state = Keyboard.GetState();

            foreach (var key in _state.GetPressedKeys())
            {
                KeyPressed?.Invoke(this, new KeyPressedArgs(key, _state[key] != _oldState[key]));
            }
        }
    }
}