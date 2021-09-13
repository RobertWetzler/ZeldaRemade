using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class FixedNonAnimatedSprite : ISprite
    {
        public Texture2D texture { private get; set; }

        private Vector2 position;

        public FixedNonAnimatedSprite()
        {
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
            position = new Vector2(windowBounds.Width / 2, windowBounds.Height / 2);
        }
    }
}
