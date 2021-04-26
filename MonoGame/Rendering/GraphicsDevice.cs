using System;
using Microsoft.Xna.Framework;
using MonoGame.Config;
using MonoGame.Config.Configurations;
using XnaGame = Microsoft.Xna.Framework.Game;

namespace MonoGame.Rendering
{
    public class GraphicsDevice
    {
        public IRenderer Renderer { get; private set; }

        public GraphicsDevice(XnaGame game, IConfigurationManager configurationManager)
        {
            var graphicsDevice = new GraphicsDeviceManager(game);
            graphicsDevice.DeviceCreated += GraphicsDeviceCreated;

            Renderer = new NoRenderer();
            
            LoadSettings(game, configurationManager, graphicsDevice);
        }

        private static void LoadSettings(XnaGame game, IConfigurationManager configurationManager, GraphicsDeviceManager graphicsDeviceManager)
        {
            var graphicsSettings = configurationManager.Load<DisplaySettingsConfiguration>();

            if (graphicsSettings.Screen.FullScreen == DisplaySettingsConfiguration.ScreenSettings.FullscreenModes.Fullscreen)
                SetFullscreen(graphicsSettings, graphicsDeviceManager);
            else
                SetWindowed(graphicsSettings, graphicsDeviceManager);
            
            game.IsMouseVisible = true;
            
            graphicsDeviceManager.SynchronizeWithVerticalRetrace = graphicsSettings.Screen.VSync;
            if (!graphicsDeviceManager.SynchronizeWithVerticalRetrace)
                game.TargetElapsedTime = CalculateFrameTime(graphicsSettings.Screen.RefreshRate);
        }

        private static TimeSpan CalculateFrameTime(double screenRefreshRate)
        {
            return new TimeSpan((long) (1000d / screenRefreshRate * 10000d));
        }

        private static void SetWindowed(DisplaySettingsConfiguration graphicsSettings, GraphicsDeviceManager graphicsDeviceManager)
        {
            graphicsDeviceManager.IsFullScreen = false;
            graphicsDeviceManager.PreferredBackBufferWidth = graphicsSettings.Screen.WindowedWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = graphicsSettings.Screen.WindowedHeight;
        }

        private static void SetFullscreen(DisplaySettingsConfiguration graphicsSettings, GraphicsDeviceManager graphicsDeviceManager)
        {
            graphicsDeviceManager.IsFullScreen = true;
            graphicsDeviceManager.PreferredBackBufferWidth = graphicsSettings.Screen.FullScreenWidth;
            graphicsDeviceManager.PreferredBackBufferHeight = graphicsSettings.Screen.FullScreenHeight;
        }

        private void GraphicsDeviceCreated(object sender, EventArgs e)
        {
            var graphicsDeviceManager = (GraphicsDeviceManager) sender;
            Renderer = new Renderer(graphicsDeviceManager.GraphicsDevice);
        }
    }
}