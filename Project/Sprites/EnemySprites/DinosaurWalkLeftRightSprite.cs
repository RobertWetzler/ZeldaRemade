using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DinosaurWalkLeftRightSprite : IEnemySprite
    {
        private Texture2D dinosaurSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter;
        private int animationDelay;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        public DinosaurWalkLeftRightSprite(Texture2D dinosaurSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dinosaurSpriteSheet = dinosaurSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.animationCounter = 0;
            this.animationDelay = 100;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle((int)xPos, (int)yPos, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dinosaurSpriteSheet, destRectangle, source, Color.White);
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