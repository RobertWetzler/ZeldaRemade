﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;


namespace Project
{
    class MerchantSprite : IEnemySprite
    {
        private Texture2D spriteSheet;

        public MerchantSprite(Texture2D spriteSheet)
        {
            this.spriteSheet = spriteSheet;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = new Rectangle(0, 0, spriteSheet.Width, spriteSheet.Height);
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                spriteSheet.Width * 3, spriteSheet.Height * 3);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
        }
        public void Update()
        {

        }
    }
}