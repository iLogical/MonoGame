using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
namespace MonoGame.Input
{

    public class InputManager : IInputManager
    {
        private readonly KeyboardInput _keyboardInput;
        private readonly ImmutableDictionary<HashSet<Keys>, InputActionType> _mappingActions;
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
            foreach (var (keysRequired, inputActionType) in _mappingActions)
            {
                var overlap = e.PressedKeys.Where(x => keysRequired.Contains(x.Key)).ToArray();
                if (overlap.Length != keysRequired.Count || !_actions.TryGetValue(inputActionType, out var inputAction))
                    continue;
                
                switch (inputAction.KeyPressType)
                {
                    case KeyPressType.Press when overlap.Any(x => x.Value):
                    case KeyPressType.Hold:
                        inputAction.Action();
                        break;
                }
            }
        }

        private static ImmutableDictionary<HashSet<Keys>, InputActionType> LoadActionMappings()
        {
            var builder = ImmutableDictionary.CreateBuilder<HashSet<Keys>, InputActionType>();
            builder.Add(new HashSet<Keys>(new[] {Keys.Escape}), InputActionType.Exit);
            builder.Add(new HashSet<Keys>(new[] {Keys.LeftControl, Keys.LeftAlt, Keys.D}), InputActionType.ToggleDebug);
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