using System;
using Microsoft.Extensions.DependencyInjection;
using MonoGame.Config;
using MonoGame.Input;
using MonoGame.Rendering;

namespace MonoGame
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var serviceProvider = BuildServiceProvider();
            using var game = serviceProvider.GetService<IGame>();
            game?.Run();
        }
        private static ServiceProvider BuildServiceProvider()
        {
            var serviceCollection = new ServiceCollection()
                .AddSingleton<IConfigurationManager, ConfigurationManager>()                
                .AddSingleton<IKeyboardInput, KeyboardInput>()
                .AddSingleton<IInputManager, InputManager>()
                .AddSingleton<IRenderer, Renderer>()
                .AddSingleton<IGame, Game>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}