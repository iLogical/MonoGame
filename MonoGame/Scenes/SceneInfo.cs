﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace MonoGame.Scenes
{
    public class SceneInfo
    {
        public List<TextData> Text { get; }
        public List<SpriteData> Sprites { get; }
        protected SceneInfo()
        {
            Text = new List<TextData>();
            Sprites = new List<SpriteData>();
        }

        public class TextData
        {
            public string Asset { get; init; }
            public string Value { get; init; }
            public Color Color { get; init; }
            public Vector2 Position { get; init; }
        }

        public class SpriteData
        {
            public string Asset { get; init; }
            public Color Color { get; init; }
            public Vector2 Position { get; init; }
            public Vector2 Scale { get; init; }
            public float Depth { get; init; }
            public List<SpriteData> Parts { get; }
            public float Rotation { get; init; }

            protected SpriteData()
            {
                Parts = new List<SpriteData>();
            }
        }
    }
}