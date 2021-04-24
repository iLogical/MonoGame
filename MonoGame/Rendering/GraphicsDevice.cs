using System;
using Microsoft.Xna.Framework;
using MonoGame.Config;
using MonoGame.Config.Configurations;

namespace MonoGame.Rendering
{
    public class GraphicsDevice
    {
        private readonly IConfigurationManager _configurationManager;
        private readonly GraphicsDeviceManager _graphicsDevice;
        private readonly Microsoft.Xna.Framework.Game _game;
        public IRenderer Renderer { get; private set; }
        public ISpriteBatch SpriteBatch { get; private set; }

        public GraphicsDevice(Microsoft.Xna.Framework.Game game, IConfigurationManager configurationManager)
        {
            _game = game;
            _configurationManager = configurationManager;
            _graphicsDevice = new GraphicsDeviceManager(_game);
            _graphicsDevice.DeviceCreated += GraphicsDeviceCreated;

            LoadSettings();

            Renderer = new NoRenderer();
            SpriteBatch = new NoSpriteBatch();
        }

        private void LoadSettings()
        {
            var graphicsSettings = _configurationManager.Load<DisplaySettingsConfiguration>();

            if (graphicsSettings.Screen.FullScreen == DisplaySettingsConfiguration.ScreenSettings.FullscreenModes.Fullscreen)
                SetFullscreen(graphicsSettings);
            else
                SetWindowed(graphicsSettings);

            _graphicsDevice.SynchronizeWithVerticalRetrace = graphicsSettings.Screen.VSync;
            if (!_graphicsDevice.SynchronizeWithVerticalRetrace)
                _game.TargetElapsedTime = new TimeSpan((long) (1000d / graphicsSettings.Screen.RefreshRate * 10000d));
        }

        private void SetWindowed(DisplaySettingsConfiguration graphicsSettings)
        {
            _graphicsDevice.IsFullScreen = false;
            _graphicsDevice.PreferredBackBufferWidth = graphicsSettings.Screen.WindowedWidth;
            _graphicsDevice.PreferredBackBufferHeight = graphicsSettings.Screen.WindowedHeight;
        }

        private void SetFullscreen(DisplaySettingsConfiguration graphicsSettings)
        {
            _graphicsDevice.IsFullScreen = true;
            _graphicsDevice.PreferredBackBufferWidth = graphicsSettings.Screen.FullScreenWidth;
            _graphicsDevice.PreferredBackBufferHeight = graphicsSettings.Screen.FullScreenHeight;
        }

        private void GraphicsDeviceCreated(object sender, EventArgs e)
        {
            var graphicsDeviceManager = (GraphicsDeviceManager) sender;
            SpriteBatch = new SpriteBatch(graphicsDeviceManager.GraphicsDevice);
            Renderer = new Renderer(graphicsDeviceManager.GraphicsDevice);
        }
    }
}