using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class MovingNonAnimatedSprite : ISprite
    {
        public Texture2D texture { private get; set; }

        private Vector2 position;

        public MovingNonAnimatedSprite()
        {
            position = new Vector2();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            int scale = 4;
            int spriteWidth = 16;
            int spriteHeight = 27;
            Rectangle destinationRectangle = new Rectangle(
                (int)position.X - scale * spriteWidth / 2,
                (int)position.Y - scale * spriteHeight / 2,
                scale * spriteWidth,
                scale * spriteHeight
                );
            spriteBatch.Draw(
                texture,
                destinationRectangle,
                new Rectangle(1, 1, spriteWidth, spriteHeight),
                Color.White,
                0f,
                Vector2.Zero,
                SpriteEffects.None,
                0f
                );
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            position.Y = (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds) * (windowBounds.Height / 4) + (windowBounds.Height / 2);
            position.X = windowBounds.Width / 2;
        }
    }
}
