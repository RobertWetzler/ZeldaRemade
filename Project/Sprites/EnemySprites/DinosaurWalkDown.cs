using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class DinosaurWalkDownSprite : ISprite
    {
        private Texture2D dinosaurSpriteSheet;
        private Rectangle sourceFrame;
        private bool flipSprite = false;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public DinosaurWalkDownSprite(Texture2D dinosaurSpriteSheet, Rectangle sourceFrame)
        {
            this.dinosaurSpriteSheet = dinosaurSpriteSheet;
            this.sourceFrame = sourceFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                sourceFrame.Width * 4, sourceFrame.Height * 4);
            if (flipSprite)
            {
                spriteBatch.Draw(dinosaurSpriteSheet, destRectangle, sourceFrame, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(dinosaurSpriteSheet, destRectangle, sourceFrame, Color.White);
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
