using Microsoft.Xna.Framework;
namespace MonoGame.Rendering
{

    public class Renderer : IRenderer
    {
        private readonly Microsoft.Xna.Framework.Graphics.GraphicsDevice _graphicsDevice;
        public Renderer(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void DrawFrame(GameTime gameTime)
        {
            _graphicsDevice.Clear(Color.CornflowerBlue);
        }
    }
}