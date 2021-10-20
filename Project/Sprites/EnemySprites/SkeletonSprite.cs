using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class SkeletonSprite : IEnemySprite
    {
        private Texture2D spriteSheet;
        private bool flipSprite;
        private int animationCounter = 0;
        private int animationDelay = 100;

        public SkeletonSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            flipSprite = false;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            if (flipSprite)
            {
                spriteBatch.Draw(spriteSheet, destination, source, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(spriteSheet, destination, Color.White);
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
