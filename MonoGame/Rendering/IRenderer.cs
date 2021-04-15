using Microsoft.Xna.Framework;
namespace MonoGame.Rendering
{
    public interface IRenderer
    {
        void DrawFrame(GameTime gameTime);
        void ToggleDebugMode();
    }
}