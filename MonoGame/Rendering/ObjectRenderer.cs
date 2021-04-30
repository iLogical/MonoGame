using System;
using System.Collections.Generic;
using MonoGame.Rendering.Renderers;

namespace MonoGame.Rendering
{
    public interface IComponentRenderer
    {
        void DrawFrame(IEnumerable<ISprite> renderQueue);
    }

    public class ComponentRenderer : IComponentRenderer
    {
        private readonly IDictionary<Type, ISpriteRenderer> _renderers;
        public ComponentRenderer(ISpriteBatch spriteBatch)
        {
            _renderers = new Dictionary<Type, ISpriteRenderer>
            {
                [typeof(ImageSprite)] = new SpriteRenderer(spriteBatch), [typeof(TextSprite)] = new TextRenderer(spriteBatch)
            };
        }

        public void DrawFrame(IEnumerable<ISprite> renderQueue)
        {
            foreach (var sprite in renderQueue)
                _renderers[sprite.GetType()].Render(sprite);
        }
    }
}