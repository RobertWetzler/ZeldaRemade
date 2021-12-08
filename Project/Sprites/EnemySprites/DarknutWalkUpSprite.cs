using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DarknutWalkUpSprite : ISprite
    {
        private Texture2D darknutSpriteSheet;
        private Rectangle sourceFrame;
        private bool flipSprite = false;
        private int currentFrame = 0;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public DarknutWalkUpSprite(Texture2D darknutSpriteSheet, Rectangle sourceFrame)
        {
            this.darknutSpriteSheet = darknutSpriteSheet;
            this.sourceFrame = sourceFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                sourceFrame.Width * 4, sourceFrame.Height * 4);
            if (flipSprite)
            {
                spriteBatch.Draw(darknutSpriteSheet, destRectangle, sourceFrame, color, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(darknutSpriteSheet, destRectangle, sourceFrame, color);
            }

        }

        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                flipSprite = !flipSprite;
               
            }

        }
    }
}