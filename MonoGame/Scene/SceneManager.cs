using System;
using System.Collections.Generic;
using MonoGame.Content;
using MonoGame.Rendering;
using MonoGame.Scene.Scenes;

namespace MonoGame.Scene
{
    public interface ISceneManager
    {
        void Initialize(IContentManager contentManager, IRenderer renderer);
        IScene Load(string sceneId);
    }

    public class SceneManager : ISceneManager
    {
        private IRenderer _renderer;
        private Dictionary<string, Func<IScene>> _scenes;
        public void Initialize(IContentManager contentManager, IRenderer renderer)
        {
            _renderer = renderer;
            _scenes = new Dictionary<string, Func<IScene>>
            {
                ["Test"] = () => new TestScene(contentManager, renderer)
            };
        }

        public IScene Load(string sceneId)
        {
            _renderer.ClearRenderQueue();
            return _scenes[sceneId]();
        }
    }

    public interface IScene
    {
        void LoadContent();
    }

}