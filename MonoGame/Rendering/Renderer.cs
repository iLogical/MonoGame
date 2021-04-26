using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Scene;
using MonoGame.Scene.Scenes;

namespace MonoGame.Rendering
{
    public interface IRenderer
    {
        void SetScene(IScene scene);
        void DrawFrame();
        void ToggleDebugMode();
    }

    public class Renderer : IRenderer
    {
        private readonly IComponentRenderer _componentRenderer;
        private readonly ISpriteBatch _spriteBatch;
        private IScene _currentScene;
        private readonly GraphicsDeviceManager _graphicsDevice;
        private Color _clearColor;
        private bool _debug;
        
        public Renderer(IComponentRenderer componentRenderer, GraphicsDeviceManager graphicsDevice, ISpriteBatch spriteBatch)
        {
            _componentRenderer = componentRenderer;
            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
            _currentScene = new NoScene();
            _clearColor = Color.CornflowerBlue;
            _debug = false;
        }

        public void SetScene(IScene scene)
        {
            _currentScene = scene;
        }

        public void DrawFrame()
        {
            _graphicsDevice.GraphicsDevice.Clear(_clearColor);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            _componentRenderer.DrawFrame(_currentScene.Components);
            _spriteBatch.End();
        }
        public void ToggleDebugMode()
        {
            _debug = _debug.Invert();
            _clearColor = _debug ? Color.DarkRed : Color.CornflowerBlue;
        }
    }
}