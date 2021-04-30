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
    }
}