using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace MonoGame.Input
{

    public class InputManager : IInputManager
    {
        private readonly KeyboardInput _keyboardInput;
        private readonly ImmutableDictionary<Keys, InputActionType> _mappingActions;
        private readonly IDictionary<InputActionType, InputAction> _actions;

        public InputManager()
        {
            _mappingActions = LoadActionMappings();
            _actions = new Dictionary<InputActionType, InputAction>();
            _keyboardInput = new KeyboardInput();

            _keyboardInput.KeyPressed += IsKeyPressed;
        }
        private void IsKeyPressed(object sender, KeyPressedArgs e)
        {
            if (!_mappingActions.TryGetValue(e.Key, out var inputActionType) || !_actions.TryGetValue(inputActionType, out var inputAction))
                return;

            switch (inputAction.KeyPressType)
            {
                case KeyPressType.Press when e.NewlyPressed:
                case KeyPressType.Hold:
                    inputAction.Action();
                    break;
            }
        }

        private static ImmutableDictionary<Keys, InputActionType> LoadActionMappings()
        {
            var builder = ImmutableDictionary.CreateBuilder<Keys, InputActionType>();
            builder.Add(Keys.Escape, InputActionType.Exit);
            builder.Add(Keys.D, InputActionType.ToggleDebug);
            return builder.ToImmutable();
        }
        public void OnInputAction(InputActionType inputActionType, Action inputAction)
        {
            _actions.Add(inputActionType, new InputAction(inputActionType, inputAction));
        }
        public void Update(GameTime gameTime)
        {
            _keyboardInput.RefreshState();
        }
    }
}