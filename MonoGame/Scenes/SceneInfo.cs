using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace MonoGame.Scenes
{
    public abstract class SceneInfo
    {
        public List<TextData> Text { get; }
        public List<SpriteData> Sprites { get; }
        protected SceneInfo()
        {
            Text = new List<TextData>();
            Sprites = new List<SpriteData>();
        }

        public abstract class TextData
        {
            public string Asset { get; init; }
            public string Value { get; init; }
            public Color Color { get; init; }
            public Vector2 Position { get; init; }
        }

        public abstract class SpriteData
        {
            public string Asset { get; init; }
            public Color Color { get; init; }
            public Vector2 Position { get; init; }
            public List<SpriteData> Parts { get; }
            protected SpriteData()
            {
                Parts = new List<SpriteData>();
            }
        }
    }
}