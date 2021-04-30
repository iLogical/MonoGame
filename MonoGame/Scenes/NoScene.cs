using System.Collections.Generic;
using MonoGame.Rendering;
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
}