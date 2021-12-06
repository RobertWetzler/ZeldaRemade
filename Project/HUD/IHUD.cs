using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.HUD
{
    public interface IHUD
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
