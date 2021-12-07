using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DinosaurWalkLeftSprite : ISprite
    {
        private Texture2D dinosaurSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter;
        private int animationDelay;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        public DinosaurWalkLeftSprite(Texture2D dinosaurSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dinosaurSpriteSheet = dinosaurSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.animationCounter = 0;
            this.animationDelay = 100;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dinosaurSpriteSheet, destRectangle, source, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
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