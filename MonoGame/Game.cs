using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Config;
using MonoGame.Content;
using MonoGame.Input;
using MonoGame.Rendering;
using MonoGame.Scenes;
using ContentManager = Microsoft.Xna.Framework.Content.ContentManager;
using GraphicsDevice = MonoGame.Rendering.GraphicsDevice;
using XnaGame = Microsoft.Xna.Framework.Game;

namespace MonoGame
{
    public interface IGame : IDisposable
    {
        void Run();
        ContentManager Content { get; }
    }

    public class Game : XnaGame, IGame
    {
        private readonly GraphicsDevice _graphicsDeviceManager;
        private readonly IInputManager _inputManager;
        private readonly IContentManager _contentManager;
        private readonly ISceneManager _sceneManager;

        public Game(IInputManager inputManager, IConfigurationManager configurationManager, IContentManager contentManager, ISceneManager sceneManager)
        {
            _graphicsDeviceManager = new GraphicsDevice(this, configurationManager);
            
            _sceneManager = sceneManager;
            _inputManager = inputManager;
            _contentManager = contentManager;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            _contentManager.Initialize(this);
            _sceneManager.Initialize(_contentManager);
            
            _inputManager.OnInputAction(InputActionType.Exit, Exit);
            _inputManager.OnInputAction(InputActionType.ToggleDebug, _graphicsDeviceManager.Renderer.ToggleDebugMode );
            base.Initialize();
        }

        protected override void LoadContent()
        {
            var scene = _sceneManager
                .Load("Test");
            _graphicsDeviceManager.Renderer.SetScene(scene);
        }

        protected override void Update(GameTime gameTime)
        {
            _inputManager.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _graphicsDeviceManager.Renderer.DrawFrame();
            base.Draw(gameTime);
        }
    }
}