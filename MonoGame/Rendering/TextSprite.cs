using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public class TextSprite : ISprite
    {
        public SpriteFont SpriteFont { get; init; }
        public string Text { get; init; }
        public Vector2 Position { get; init; }
        public Color Color { get; init; }

        public TextSprite(SpriteFont spriteFont, string text)
        {
            SpriteFont = spriteFont;
            Text = text;
            Position = Vector2.Zero;
            Color = Color.White;
        }
    }
}