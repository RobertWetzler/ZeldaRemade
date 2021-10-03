using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class SkeletonSprite : IEnemySprite
    {
        private Texture2D spriteSheet;
        private bool flipSprite;
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

        public void Update()
        {
            flipSprite = flipSprite ? false : true;
        }
    }
}
