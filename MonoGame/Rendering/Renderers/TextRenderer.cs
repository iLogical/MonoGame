namespace MonoGame.Rendering.Renderers
{
    public class TextRenderer : ISpriteRenderer
    {
        private readonly ISpriteBatch _spriteBatch;
        public TextRenderer(ISpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Render(ISprite o)
        {
            var toRender = (TextSprite)o;
            Render(toRender);
        }
        private void Render(TextSprite toRender)
        {
            _spriteBatch.DrawString(toRender.SpriteFont, toRender.Text, toRender.Position, toRender.Color);
        }
    }

}