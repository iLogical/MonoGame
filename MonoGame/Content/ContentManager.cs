using System;
using XnaGame = Microsoft.Xna.Framework.Game;
using XnaContentManager = Microsoft.Xna.Framework.Content.ContentManager;

namespace MonoGame.Content
{
    public interface IContentManager : IDisposable
    {
        void Initialize(IGame game);
        T LoadLocalized<T>(string assetName);
        T Load<T>(string assetName);
    }

    public class ContentManager : IContentManager
    {
        private XnaContentManager _contentManager;
        public void Initialize(IGame game)
        {
            _contentManager = game.Content;
        }
        public T LoadLocalized<T>(string assetName)
        {
            return _contentManager.LoadLocalized<T>(assetName);
        }
        public T Load<T>(string assetName)
        {
            return _contentManager.Load<T>(assetName);
        }
        public void Dispose()
        {
            _contentManager.Dispose();
        }
    }
}