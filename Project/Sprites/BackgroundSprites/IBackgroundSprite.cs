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
        void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            this.Draw(spriteBatch, graphics, Vector2.Zero);
        }
        void Draw(SpriteBatch spriteBatch, GraphicsDeviceManager graphics, Vector2 offset);
    }
}
