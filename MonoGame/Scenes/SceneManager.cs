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
        private IContentManager _contentManager;
        public void Initialize(IContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public IScene Load(string sceneId)
        {
            return new Scene(_contentManager).LoadContent(sceneId);
        }
    }

    public interface IScene
    {
        List<ISprite> Components { get; }
    }
}