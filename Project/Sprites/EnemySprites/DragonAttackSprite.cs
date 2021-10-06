using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class DragonAttackSprite : IEnemySprite
    {
        private Texture2D dragonSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;

        public DragonAttackSprite(Texture2D dragonSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.dragonSpriteSheet = dragonSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle((int)xPos, (int)yPos, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dragonSpriteSheet, destination, source, Color.White);
        }
        public void Update()
        {
            currentFrame++;
            currentFrame %= sourceFrames.Count;
        }
    }
}
