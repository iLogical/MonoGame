using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Content;
using MonoGame.Rendering;

namespace MonoGame.Scene.Scenes
{
    public class TestScene : IScene
    {
        private readonly IContentManager _contentManager;
        private readonly IRenderer _renderer;
        public TestScene(IContentManager contentManager, IRenderer renderer)
        {
            _contentManager = contentManager;
            _renderer = renderer;
        }


        public void LoadContent()
        {
            var spriteFont = _contentManager.Load<SpriteFont>("fonts//Arial");
            _renderer.AddToRenderQueue(new TextSprite {SpriteFont = spriteFont, Text = "Test", Color = Color.White, Position = Vector2.Zero});
            _renderer.AddToRenderQueue(new TextSprite {SpriteFont = spriteFont, Text = "More Text", Color = Color.Black, Position = new Vector2(400.0f, 300.0f)});
        }
    }
}