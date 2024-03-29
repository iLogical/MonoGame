﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Config;
using MonoGame.Config.Configurations;
namespace MonoGame.Input
{
    public interface IInputManager
    {
        void OnInputAction(InputActionType inputActionType, Action inputAction);
        void Update(GameTime gameTime);
    }
    public class InputManager : IInputManager
    {
        private readonly IKeyboardInput _keyboardInput;
        private readonly IDictionary<HashSet<Keys>, InputActionType> _mappingActions;
        private readonly IDictionary<InputActionType, InputAction> _actions;

        public InputManager(IConfigurationManager configurationManage, IKeyboardInput keyboardInput)
        {            
            _keyboardInput = keyboardInput;
            _mappingActions = LoadActionMappings(configurationManage);
            _actions = new Dictionary<InputActionType, InputAction>();

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
        private static IDictionary<HashSet<Keys>, InputActionType> LoadActionMappings(IConfigurationManager configurationManager)
        {            
            var builder = new Dictionary<HashSet<Keys>, InputActionType>();
            var loadedBindings = configurationManager.Load<KeyBindingConfiguration>();
            foreach (var (inputActionType, keyBinding) in loadedBindings.Actions)
            {
                var primaryBindings = keyBinding.Primary.ToHashSet();
                if(primaryBindings.Any())
                    builder.Add(primaryBindings, inputActionType);
                var secondaryBindings = keyBinding.Secondary.ToHashSet();
                if(secondaryBindings.Any())
                    builder.Add(secondaryBindings, inputActionType);
            }
            return builder;
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