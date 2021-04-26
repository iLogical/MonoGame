using System.Collections.Generic;
namespace MonoGame.Rendering
{
    public class NoComponentRenderer : IComponentRenderer
    {
        public ISpriteBatch SpriteBatch { get; }

        public NoComponentRenderer(ISpriteBatch spriteBatch)
        {
            SpriteBatch = spriteBatch;
        }
        public void DrawFrame(IEnumerable<ISprite> renderQueue)
        {
        }
        public void ToggleDebugMode()
        {
        }
        public void AddToRenderQueue<T>(T item) where T : ISprite
        {
        }
        public void ClearRenderQueue()
        {
        }
    }
}