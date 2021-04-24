using System;
using Microsoft.Xna.Framework;
using MonoGame.Config;
using MonoGame.Input;
using MonoGame.Rendering;
using XnaGame = Microsoft.Xna.Framework.Game;

namespace MonoGame
{
    public interface IGame : IDisposable
    {
        void Run();
    }

    public class Game : XnaGame, IGame
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly IInputManager _inputManager;

        public Game(IInputManager inputManager, IConfigurationManager configurationManager)
        {
            _graphicsDevice = new GraphicsDevice(this, configurationManager);
            _inputManager = inputManager;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _inputManager.OnInputAction(InputActionType.Exit, Exit);
            _inputManager.OnInputAction(InputActionType.ToggleDebug, _graphicsDevice.Renderer.ToggleDebugMode );
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