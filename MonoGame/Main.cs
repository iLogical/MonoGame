﻿using Microsoft.Xna.Framework;
using MonoGame.Input;
using MonoGame.Rendering;

namespace MonoGame
{
    public class Main : Game
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly InputManager _inputManager;

        public Main()
        {
            _graphicsDevice = new GraphicsDevice(this);
            _inputManager = new InputManager();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _inputManager.OnInputAction(InputActionType.Exit, Exit);
            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphicsDevice.Renderer.DrawFrame(gameTime);
            base.Draw(gameTime);
        }
    }
}