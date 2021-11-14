using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Sprites.BackgroundSprites
{
    interface IBackgroundSprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Rectangle destRect);
        void Draw(SpriteBatch spriteBatch, Rectangle destRect, Vector2 offset)
        {
            Draw(spriteBatch, destRect);
        }
    }
}
