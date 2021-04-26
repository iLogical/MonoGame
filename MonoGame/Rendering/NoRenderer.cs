using Microsoft.Xna.Framework;
namespace MonoGame.Rendering
{
    public class NoRenderer : IRenderer
    {
        public ISpriteBatch SpriteBatch { get; }

        public NoRenderer()
        {
            SpriteBatch = new NoSpriteBatch();
        }
        public void DrawFrame(GameTime gameTime)
        {
        }
        public void ToggleDebugMode()
        {
        }
        public void AddToRenderQueue<T>(T item) where T : ISprite
        {
        }
    }
}