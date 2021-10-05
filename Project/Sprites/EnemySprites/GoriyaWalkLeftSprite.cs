using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class GoriyaWalkLeftSprite : IEnemySprite
    {
        private Texture2D goriyaSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;

        public GoriyaWalkLeftSprite(Texture2D goriyaSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.goriyaSpriteSheet = goriyaSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 4, source.Height * 4);
            spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= sourceFrames.Count;
        }
    }
}
