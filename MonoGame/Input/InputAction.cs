using System;
namespace MonoGame.Input
{
    public class InputAction
    {
        public InputActionType Type { get; }
        public Action Action { get; }
        public KeyPressType KeyPressType { get; }
        public InputAction(InputActionType type, Action action, KeyPressType keyPressType = KeyPressType.Press)
        {
            Type = type;
            Action = action;
            KeyPressType = keyPressType;
        }
    }
}