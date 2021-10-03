﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Project.Factory;

namespace Project.NPC.Merchant
{
    class Merchant : INPC
    {
        public float xPos, yPos;

        public Merchant()
        {
            this.xPos = 400;
            this.yPos = 100;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D texture = NPCSpriteFactory.Instance.GetMerchantSpriteSheet();
            Rectangle source = NPCSpriteFactory.MERCHANT;
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }


        public void Update()
        {

        }
    }

}