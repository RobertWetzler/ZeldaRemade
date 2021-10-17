using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    public interface IEnemySprite
    {
        void Draw(SpriteBatch spriteBatch, float xPos, float yPos);
        void Update(GameTime gameTime);
    }
}
