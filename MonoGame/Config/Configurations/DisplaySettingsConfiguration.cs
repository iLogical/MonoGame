namespace MonoGame.Config.Configurations
{
    public class DisplaySettingsConfiguration
    {
        public ScreenSettings Screen { get; set; }

        public class ScreenSettings
        {
            public int FullScreenWidth { get; set; }
            public int FullScreenHeight { get; set; }
            public int WindowedWidth { get; set; }
            public int WindowedHeight { get; set; }
            public double RefreshRate { get; set; }
            public bool VSync { get; set; }
            public FullscreenModes FullScreen { get; set; }

            public enum FullscreenModes
            {
                Windowed,
                Fullscreen,
                BorderlessWindowed
            }
        }
    }
}