using System;
using Microsoft.Xna.Framework;
namespace MonoGame.Rendering
{
    public class GraphicsDevice
    {        
        public IRenderer Renderer { get; private set; }
        public ISpriteBatch SpriteBatch { get; private set; }
        
        public GraphicsDevice(Game game)
        {
            new GraphicsDeviceManager(game)
                .DeviceCreated += GraphicsDeviceCreated;
            Renderer = new NoRenderer();
            SpriteBatch = new NoSpriteBatch();
        }
        private void GraphicsDeviceCreated(object sender, EventArgs e)
        {
            var graphicsDeviceManager = (GraphicsDeviceManager)sender;
            SpriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            Renderer = new Renderer(graphicsDeviceManager.GraphicsDevice);
        }
    }
}