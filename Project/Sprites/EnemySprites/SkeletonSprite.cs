using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project
{
    class SkeletonSprite : ISprite
    {
        private Texture2D spriteSheet;
        private bool flipSprite;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public SkeletonSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
            flipSprite = false;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            if (flipSprite)
            {
                spriteBatch.Draw(spriteSheet, destRectangle, source, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
            else
            {
                spriteBatch.Draw(spriteSheet, destRectangle, Color.White);
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
