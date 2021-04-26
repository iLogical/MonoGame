using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public interface IRenderer
    {
        void DrawFrame(GameTime gameTime);
        void ToggleDebugMode();
        void AddToRenderQueue<T>(T item) where T : ISprite;
        void ClearRenderQueue();
    }

    public class Renderer : IRenderer
    {
        private readonly HashSet<ISprite> _renderQueue;
        private readonly IDictionary<Type, Action<ISprite>> _renderers;
        private readonly Microsoft.Xna.Framework.Graphics.GraphicsDevice _graphicsDevice;
        private Color _clearColor;
        private bool _debug;
        private readonly SpriteBatch _spriteBatch;
        public Renderer(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;            
            _renderers = new Dictionary<Type, Action<ISprite>>
            {
                [typeof(ImageSprite)] = DrawSprite,
                [typeof(TextSprite)] = DrawString,
            };
            
            _renderQueue = new HashSet<ISprite>();
            _spriteBatch = new SpriteBatch(_graphicsDevice);
            _clearColor = Color.CornflowerBlue;
            _debug = false;
        }

        public void ToggleDebugMode()
        {
            _debug = _debug.Invert();
            _clearColor = _debug ? Color.DarkRed : Color.CornflowerBlue;
        }

        public void DrawFrame(GameTime gameTime)
        {
            _graphicsDevice.Clear(_clearColor);
            _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.NonPremultiplied);
            foreach (var toRender in _renderQueue)
            {
                _renderers[toRender.GetType()](toRender);
            }
            _spriteBatch.End();
        }

        public void AddToRenderQueue<T>(T item) where T : ISprite
        {
            _renderQueue.Add(item);
        }

        public void ClearRenderQueue()
        {
            _renderQueue.Clear();
        }

        private void DrawSprite(ISprite o)
        {
            var toRender = (ImageSprite)o;
            _spriteBatch.Draw(toRender.Texture, toRender.Position, toRender.Color);
        }

        private void DrawString(ISprite o)
        {
            var toRender = (TextSprite)o;
            _spriteBatch.DrawString(toRender.SpriteFont, toRender.Text, toRender.Position, toRender.Color);
        }
    }
}