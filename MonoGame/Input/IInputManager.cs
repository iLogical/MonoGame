using System;
using Microsoft.Xna.Framework;
namespace MonoGame.Input
{
    public interface IInputManager
    {
        void OnInputAction(InputActionType inputActionType, Action inputAction);
        void Update(GameTime gameTime);
    }
}