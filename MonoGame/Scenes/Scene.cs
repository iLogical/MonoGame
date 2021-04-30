using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Content;
using MonoGame.Rendering;
using Newtonsoft.Json;
namespace MonoGame.Scenes
{
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
            
            Components.AddRange(Load(sceneJson!.Text));
            Components.AddRange(Load(sceneJson!.Sprites));
            return this;
        }
        private IEnumerable<TextSprite> Load(IEnumerable<SceneInfo.TextData> textToLoad)
        {
            return textToLoad.Select(DataToModel);
        }
        private TextSprite DataToModel(SceneInfo.TextData textObject)
        {
            return new()
            {
                SpriteFont = _contentManager.Load<SpriteFont>($"fonts//{textObject.Asset}"), 
                Text = textObject.Value, 
                Color = textObject.Color, 
                Position = textObject.Position
            };
        }

        private IEnumerable<ImageSprite> Load(IEnumerable<SceneInfo.SpriteData> spritesToLoad)
        {
            return spritesToLoad.Select(DataToModel);
        }
        private ImageSprite DataToModel(SceneInfo.SpriteData spriteObject)
        {
            return new()
            {
                Texture = _contentManager.Load<Texture2D>($"sprites//{spriteObject.Asset}"), 
                Color = spriteObject.Color, 
                Position = spriteObject.Position, 
                Parts = Load(spriteObject.Parts)
            };
        }
    }
}