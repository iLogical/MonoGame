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
            Render(toRender, new ImageSprite());
        }
        private void Render(ImageSprite o, ImageSprite p)
        {
            _spriteBatch.Draw(o.Texture, p.Position + o.Position, o.Color);
            foreach (var child in o.Parts)
                Render(child, p);
        }
    }
}