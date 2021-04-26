using System;

namespace MonoGame
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = Bootstrapper.Run();
            game?.Run();
        }
    }
}