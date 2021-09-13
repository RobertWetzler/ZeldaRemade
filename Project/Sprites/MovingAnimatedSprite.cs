using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class MovingAnimatedSprite : ISprite
    {
        public Texture2D texture { private get; set; }

        private Vector2 position;
        private int tick;

        public MovingAnimatedSprite()
        {
            tick = 0;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            int scale = 4;
            int screenWidth = spriteBatch.GraphicsDevice.PresentationParameters.BackBufferWidth;
            int screenHeight = spriteBatch.GraphicsDevice.PresentationParameters.BackBufferHeight;
            int spriteWidth = 16;
            int spriteHeight = 27;
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X - scale * spriteWidth / 2,
                (int)position.Y - scale * spriteHeight / 2,
                scale * spriteWidth,
                scale * spriteHeight
                );

            int frame = (int)(gameTime.TotalGameTime.TotalSeconds * 5) % 5;
            spriteBatch.Draw(
                texture,
                destinationRectangle,
                new Rectangle(frame * (spriteWidth + 2), 1, spriteWidth + 1, spriteHeight),
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0f
                );
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            position.X = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds) * (windowBounds.Width / 4) + (windowBounds.Width / 2);
            position.Y = windowBounds.Height / 2;
        }
    }
}
