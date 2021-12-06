using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class GoriyaWalkLeftSprite : ISprite
    {
        private Texture2D goriyaSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public GoriyaWalkLeftSprite(Texture2D goriyaSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.goriyaSpriteSheet = goriyaSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                source.Width * 4, source.Height * 4);
            spriteBatch.Draw(goriyaSpriteSheet, destRectangle, source, color, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
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
