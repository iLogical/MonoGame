using Microsoft.Xna.Framework;
namespace MonoGame.Rendering.Renderers
{
    public class SpriteRenderer : ISpriteRenderer
    {
        private readonly ISpriteBatch _spriteBatch;
        public SpriteRenderer(ISpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }
        public void Render(ISprite o)
        {
            var toRender = (ImageSprite)o;
            Render(toRender, Vector2.Zero);
        }
        private void Render(ImageSprite o, Vector2 worldPosition)
        {
            _spriteBatch.Draw(o.Texture, o.Position, o.Color);
            foreach (var child in o.Parts)
            {
                var position = worldPosition += child.Position;
                Render(child, position);
            }
        }
    }
}