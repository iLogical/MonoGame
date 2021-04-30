using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public class ImageSprite : ISprite
    {
        public Texture2D Texture { get; init; }
        public Vector2 Position { get; init; }
        public Color Color { get; init; }
        public IEnumerable<ImageSprite> Parts { get; init; }

        public ImageSprite()
        {
            Parts = new List<ImageSprite>();
            Position = Vector2.Zero;
        }
    }
}