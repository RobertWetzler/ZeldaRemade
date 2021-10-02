using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class GoriyaWalkRightSprite : IEnemySprite
    {
        private Texture2D goriyaSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;

        public GoriyaWalkRightSprite(Texture2D goriyaSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.goriyaSpriteSheet = goriyaSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            currentFrame %= sourceFrames.Count;
        }
    }
}
