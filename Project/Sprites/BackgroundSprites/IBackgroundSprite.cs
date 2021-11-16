using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Sprites.BackgroundSprites
{
    interface IBackgroundSprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Rectangle destRect);
        void Draw(SpriteBatch spriteBatch, Rectangle destRect, Vector2 offset)
        {
            Rectangle offsetRect = new Rectangle(destRect.X + (int)offset.X, destRect.Y + (int)offset.Y, destRect.Width, destRect.Height);
            Draw(spriteBatch, offsetRect);
        }
    }
}
