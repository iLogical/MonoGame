using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Content;
using MonoGame.Rendering;
using Newtonsoft.Json;
namespace MonoGame.Scenes
{
    public class NoScene : IScene
    {
        public List<ISprite> Components { get; }

        public NoScene()
        {
            Components = new List<ISprite>();
        }
        
        public IScene LoadContent(string value)
        {
            return this;
        }
    }
    
    public class Scene : IScene
    {
        public List<ISprite> Components { get; }

        private readonly IContentManager _contentManager;
        public Scene(IContentManager contentManager)
        {
            _contentManager = contentManager;
            Components = new List<ISprite>();
        }
        
        public IScene LoadContent(string value)
        {
            var sceneJson = JsonConvert.DeserializeObject<SceneInfo>(File.ReadAllText($"Scenes//{value}.json"));

            if (sceneJson.IsNull())
                return this;
            
            foreach (var textObject in sceneJson!.Text.GroupBy(x => x.Asset))
            {
                
                var spriteFont = _contentManager.Load<SpriteFont>($"fonts//{textObject.Key}");
                foreach (var data in textObject)
                {
                    Components.Add(new TextSprite{ SpriteFont =  spriteFont, Text = data.Value, Color = data.Color, Position = data.Position});
                }
            }
            
            foreach (var spriteObject in sceneJson.Sprites.GroupBy(x => x.Asset))
            {
                
                var texture2D = _contentManager.Load<Texture2D>($"sprites//{spriteObject.Key}");
                foreach (var data in spriteObject)
                {
                    Components.Add(new ImageSprite{ Texture =  texture2D, Color = data.Color, Position = data.Position});
                }
            }
            return this;
        }

        public class SceneInfo
        {
            public List<TextData> Text { get; init; }
            public List<SpriteData> Sprites { get; init; }

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
            }
        }
    }
}