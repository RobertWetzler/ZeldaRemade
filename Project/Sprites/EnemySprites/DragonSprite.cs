using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DragonSprite : IEnemySprite
    {
        private Texture2D dragonSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter;
        private int animationDelay;

        public DragonSprite(Texture2D dragonSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dragonSpriteSheet = dragonSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.animationCounter = 0;
            this.animationDelay = 100;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dragonSpriteSheet, destination, source, Color.White);
        }
        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                currentFrame++;
                currentFrame %= sourceFrames.Count;
            }

        }
    }
}
