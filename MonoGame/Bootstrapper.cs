using Microsoft.Extensions.DependencyInjection;
using MonoGame.Config;
using MonoGame.Content;
using MonoGame.Input;
using MonoGame.Rendering;
using MonoGame.Scene;
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
                .AddSingleton<IContentManager, ContentManager>()
                .AddSingleton<ISceneManager, SceneManager>()
                .AddSingleton<IRenderer, Renderer>()
                .AddSingleton<IGame, Game>();
        }
    }
}