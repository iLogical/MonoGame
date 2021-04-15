using System;
using Microsoft.Extensions.DependencyInjection;

namespace MonoGame
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var serviceProvider = ServiceProviderManager.Build();
            using var game = serviceProvider.GetService<IGame>();
            game?.Run();
        }
    }
}