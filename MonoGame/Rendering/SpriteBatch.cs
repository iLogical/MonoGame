namespace MonoGame.Rendering
{
    public class SpriteBatch : Microsoft.Xna.Framework.Graphics.SpriteBatch, ISpriteBatch
    {

        public SpriteBatch(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice) : base(graphicsDevice)
        {
        }
        public SpriteBatch(Microsoft.Xna.Framework.Graphics.GraphicsDevice graphicsDevice, int capacity) : base(graphicsDevice, capacity)
        {
        }
    }
}