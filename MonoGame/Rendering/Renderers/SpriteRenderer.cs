using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering.Renderers
{
    public class SpriteRenderer : ISpriteRenderer
    {
        private readonly ISpriteBatch _spriteBatch;
        public SpriteRenderer(ISpriteBatch spriteBatch) => _spriteBatch = spriteBatch;
        public void Render(ISprite o) => Render((ImageSprite)o);
        private void Render(ImageSprite o)
        {
            _spriteBatch.Draw(o.Texture, o.WorldPosition, null, o.Color, o.WorldRotation, o.Origin, o.WorldScale, SpriteEffects.None, o.WorldDepth);
            foreach (var child in o.Parts)
                Render(child);
        }
    }
}