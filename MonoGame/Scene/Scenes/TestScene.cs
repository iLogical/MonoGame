using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Content;
using MonoGame.Rendering;

namespace MonoGame.Scene.Scenes
{
    public class TestScene : IScene
    {        
        public List<ISprite> Components { get; }

        private readonly IContentManager _contentManager;
        public TestScene(IContentManager contentManager)
        {
            _contentManager = contentManager;
            Components = new List<ISprite>();
        }


        public IScene LoadContent()
        {
            var spriteFont = _contentManager.Load<SpriteFont>("fonts//Arial");
            Components.Add(new TextSprite {SpriteFont = spriteFont, Text = "Test", Color = Color.White, Position = Vector2.Zero});
            Components.Add(new TextSprite {SpriteFont = spriteFont, Text = "More Text", Color = Color.Black, Position = new Vector2(400.0f, 300.0f)});
            return this;
        }
    }

    public class NoScene : IScene
    {
        public List<ISprite> Components { get; }

        public NoScene()
        {
            Components = new List<ISprite>();
        }

        public IScene LoadContent()
        {
            return this;
        }
    }
}