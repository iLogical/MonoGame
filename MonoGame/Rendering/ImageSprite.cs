#nullable enable
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace MonoGame.Rendering
{
    public class ImageSprite : ISprite
    {
        private ImageSprite? _parent;
        public Texture2D Texture { get; }
        public Vector2 LocalPosition { get; init; }
        public Vector2 WorldPosition => LocalPosition + (_parent?.WorldPosition ?? Vector2.Zero);
        public Color Color { get; init; }
        public List<ImageSprite> Parts { get; }
        public float LocalDepth { get; init; }
        public float WorldDepth => (_parent?.WorldDepth ?? 1.0f) - LocalDepth * 0.1f;
        public float LocalRotation { get; init; }
        public float WorldRotation => LocalRotation + (_parent?.WorldRotation ?? 0.0f);
        public Vector2 Origin => new Vector2(Texture.Width * 0.5f , Texture.Height * 0.5f) * LocalScale * (_parent?.Origin ?? Vector2.Zero);
        public Vector2 LocalScale { get; init; }
        public Vector2 WorldScale => LocalScale * (_parent?.WorldScale ?? Vector2.One);
        
        public ImageSprite(Texture2D texture)
        {
            Texture = texture;
            Parts = new List<ImageSprite>();
        }

        public ImageSprite AddParts(IEnumerable<ImageSprite> parts)
        {
            foreach (var part in parts)
            {
                part.SetParent(this);
                Parts.Add(part);
            }
            return this;
        }
        private void SetParent(ImageSprite parent)
        {
            _parent = parent;
        }
    }
}