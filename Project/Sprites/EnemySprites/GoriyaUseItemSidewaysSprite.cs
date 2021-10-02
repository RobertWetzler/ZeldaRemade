using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project 
{ 
    class GoriyaUseItemSidewaysSprite : IEnemySprite
    {
        private Texture2D goriyaSpriteSheet;
        private List<Rectangle> sourceFrames;
        private bool facingRight;
        private int currentFrame = 0;

        public GoriyaUseItemSidewaysSprite(Texture2D goriyaSpriteSheet, List<Rectangle> sourceFrames, bool facingRight)
        {
            this.goriyaSpriteSheet = goriyaSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.facingRight = facingRight;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            
            if (facingRight)
            {
                spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White);
            }
            else
            {
                spriteBatch.Draw(goriyaSpriteSheet, destination, source, Color.White, 0f, new Vector2(), SpriteEffects.FlipHorizontally, 0f);
            }
        }

        public void Update()
        {

            currentFrame++;
            currentFrame %= sourceFrames.Count;

        }
    }
}
