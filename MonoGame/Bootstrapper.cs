using Microsoft.Extensions.DependencyInjection;
using MonoGame.Config;
using MonoGame.Input;
using MonoGame.Rendering;
namespace MonoGame
{
    public static class Bootstrapper
    {
        public static IGame Run()
        {
            return ServiceProviderManager
                .Build()
                .GetService<IGame>();
        }

        private static class ServiceProviderManager
        {
            public static ServiceProvider Build()
            {
                return new ServiceCollection()
                    .AddDependencies()
                    .BuildServiceProvider();
            }
        }

        private static IServiceCollection AddDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IConfigurationManager, ConfigurationManager>()
                .AddSingleton<IKeyboardInput, KeyboardInput>()
                .AddSingleton<IInputManager, InputManager>()
                .AddSingleton<IRenderer, Renderer>()
                .AddSingleton<IGame, Game>();
        }
    }
}