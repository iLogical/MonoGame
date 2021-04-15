using Microsoft.Xna.Framework;
namespace MonoGame.Rendering
{

    public class Renderer : IRenderer
    {
        private readonly Microsoft.Xna.Framework.Graphics.GraphicsDevice _graphicsDevice;
        private Color _clearColor;
        private bool _debug;
        public Renderer(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
            _clearColor = Color.CornflowerBlue;
            _debug = false;
        }

        public void ToggleDebugMode()
        {
            _debug = _debug.Invert();
            _clearColor = _debug ? Color.DarkRed : Color.CornflowerBlue;
        }

        public void DrawFrame(GameTime gameTime)
        {
            _graphicsDevice.Clear(_clearColor);
        }
    }
}