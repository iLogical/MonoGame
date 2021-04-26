using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public interface ISpriteBatch : IDisposable
    {
        void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null);
        void End();
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth);
        void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color);
        void Draw(Texture2D texture, Vector2 position, Color color);
        void Draw(Texture2D texture, Rectangle destinationRectangle, Color color);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth);
        void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth);
    }

    public class SpriteBatch : ISpriteBatch
    {
        private readonly Func<ISpriteBatch> _create;
        private ISpriteBatch _spriteBatch;

        public SpriteBatch(IGraphicsDeviceService graphicsDevice)
        {
            _spriteBatch = new NoSpriteBatch();
            _create = () => new InternalSpriteBatch(graphicsDevice.GraphicsDevice);
            graphicsDevice.DeviceCreated += OnGraphicsDeviceCreated;
        }
        private void OnGraphicsDeviceCreated(object sender, EventArgs e)
        {
            _spriteBatch = _create();
        }
        public SpriteBatch(IGraphicsDeviceService graphicsDevice, int capacity)
        {
            _spriteBatch = new NoSpriteBatch();
            _create = () => new InternalSpriteBatch(graphicsDevice.GraphicsDevice, capacity);
        }
        
        public void Dispose()
        {
            _spriteBatch.Dispose();
        }
        public void Begin(SpriteSortMode sortMode = SpriteSortMode.Deferred, BlendState blendState = null, SamplerState samplerState = null, DepthStencilState depthStencilState = null, RasterizerState rasterizerState = null, Effect effect = null, Matrix? transformMatrix = null)
        {
            _spriteBatch.Begin(sortMode, blendState, samplerState, depthStencilState, rasterizerState, effect, transformMatrix);
        }
        public void End()
        {
            _spriteBatch.End();
        }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.Draw(texture, position, sourceRectangle, color, rotation, origin, scale, effects, layerDepth);
        }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color, rotation, origin, effects, layerDepth);
        }
        public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
        {
            _spriteBatch.Draw(texture, position, sourceRectangle, color);
        }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
        {
            _spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, color);
        }
        public void Draw(Texture2D texture, Vector2 position, Color color)
        {
            _spriteBatch.Draw(texture, position, color);
        }
        public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
        {
            _spriteBatch.Draw(texture, destinationRectangle, color);
        }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color);
        }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }
        public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }
        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color);
        }
        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }
        public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            _spriteBatch.DrawString(spriteFont, text, position, color, rotation, origin, scale, effects, layerDepth);
        }
        
        private class InternalSpriteBatch : Microsoft.Xna.Framework.Graphics.SpriteBatch, ISpriteBatch
        {
            public InternalSpriteBatch(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice) : base(graphicsDevice)
            {
            }
            public InternalSpriteBatch(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice, int capacity) : base(graphicsDevice, capacity)
            {
            }
        }

        private class NoSpriteBatch : ISpriteBatch
        {
            public void Dispose()
            {
            }
            public void Begin(SpriteSortMode sortMode, BlendState blendState, SamplerState samplerState, DepthStencilState depthStencilState, RasterizerState rasterizerState, Effect effect, Matrix? transformMatrix)
            {
            }
            public void End()
            {
            }
            public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            {
            }
            public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
            {
            }
            public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color, float rotation, Vector2 origin, SpriteEffects effects, float layerDepth)
            {
            }
            public void Draw(Texture2D texture, Vector2 position, Rectangle? sourceRectangle, Color color)
            {
            }
            public void Draw(Texture2D texture, Rectangle destinationRectangle, Rectangle? sourceRectangle, Color color)
            {
            }
            public void Draw(Texture2D texture, Vector2 position, Color color)
            {
            }
            public void Draw(Texture2D texture, Rectangle destinationRectangle, Color color)
            {
            }
            public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color)
            {
            }
            public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
            {
            }
            public void DrawString(SpriteFont spriteFont, string text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            {
            }
            public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color)
            {
            }
            public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, float scale, SpriteEffects effects, float layerDepth)
            {
            }
            public void DrawString(SpriteFont spriteFont, StringBuilder text, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
            {
            }
        }

    }
}