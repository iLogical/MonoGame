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

            var eventArgs = new KeyPressedArgs();
            foreach (var pressedKey in _state.GetPressedKeys())
            {
                eventArgs.AddPressedKey(pressedKey, _oldState[pressedKey] == KeyState.Up);
            }

            KeyPressed?.Invoke(this, eventArgs);
        }
    }
}