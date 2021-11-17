using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.HUD
{
    public interface IHUD
    {
        void Update();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
