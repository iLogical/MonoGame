using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public class TextSprite : ISprite
    {
        public SpriteFont SpriteFont { get; set; }
        public string Text { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
    }
}