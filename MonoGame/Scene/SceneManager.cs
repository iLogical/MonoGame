using System;
using System.Collections.Generic;
using MonoGame.Content;
using MonoGame.Rendering;
using MonoGame.Scene.Scenes;

namespace MonoGame.Scene
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
                ["Test"] = () => new TestScene(contentManager)
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
        IScene LoadContent();
        List<ISprite> Components { get; }
    }
}