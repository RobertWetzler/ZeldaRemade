using Microsoft.Xna.Framework.Graphics;

namespace Project.HUD
{
    public interface IHUD
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
