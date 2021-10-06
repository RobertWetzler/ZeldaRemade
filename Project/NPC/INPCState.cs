using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface INPCState
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update(GameTime gameTime);
    }
}
