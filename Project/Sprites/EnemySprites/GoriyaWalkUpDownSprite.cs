using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class GoriyaWalkUpDownSprite : IEnemySprite
    {
        private Texture2D goriyaSpriteSheet;
        private Rectangle sourceFrame;
        private bool flipSprite = false;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public GoriyaWalkUpDownSprite(Texture2D goriyaSpriteSheet, Rectangle sourceFrame)
        {
            this.goriyaSpriteSheet = goriyaSpriteSheet;
            this.sourceFrame = sourceFrame;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            destRectangle = new Rectangle(
                (int)xPos, (int)yPos,
                sourceFrame.Width * 4, sourceFrame.Height * 4);
            if (flipSprite)
            {
                spriteBatch.Draw(goriyaSpriteSheet, destRectangle, sourceFrame, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(goriyaSpriteSheet, destRectangle, sourceFrame, Color.White);
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
