using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class FixedAnimatedSprite : ISprite
    {
        public Texture2D texture { private get; set; }

        private Vector2 position;

        public FixedAnimatedSprite()
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

            int frame = (int)(gameTime.TotalGameTime.TotalSeconds * 5) % 5;
            spriteBatch.Draw(
                texture,
                destinationRectangle,
                // make use of padding around sprite to avoid clipping
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
            position = new Vector2(windowBounds.Width / 2, windowBounds.Height / 2);
        }
    }
}
