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
            Render(toRender);
        }
        private void Render(ImageSprite o)
        {
            _spriteBatch.Draw(o.Texture, o.Position, o.Color);
        }
    }
}