using System;
using System.Collections.Generic;
using MonoGame.Content;
using MonoGame.Rendering;
namespace MonoGame.Scenes
{
    public interface ISceneManager
    {
        void Initialize(IContentManager contentManager);
        IScene Load(string sceneId);
    }

    public class SceneManager : ISceneManager
    {
        private Dictionary<string, Func<IScene>> _scenes;
        public void Initialize(IContentManager contentManager)
        {
            _scenes = new Dictionary<string, Func<IScene>>
            {
                ["Test"] = () => new Scene(contentManager)
            };
        }

        public IScene Load(string sceneId)
        {
            var scene = _scenes[sceneId]();
            return scene;
        }
    }

    public interface IScene
    {
        IScene LoadContent(string value);
        List<ISprite> Components { get; }
    }
}