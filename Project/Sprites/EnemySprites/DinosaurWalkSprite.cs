using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DinosaurWalkSprite : IEnemySprite
    {
        private Texture2D dinosaurSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;

        public DinosaurWalkSprite(Texture2D dinosaurSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dinosaurSpriteSheet = dinosaurSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dinosaurSpriteSheet, destination, source, Color.White);
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= sourceFrames.Count;
        }
    }
}