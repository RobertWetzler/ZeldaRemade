﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Goriya
{
    class GoriyaWalkSouth : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public GoriyaWalkSouth(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = NPCSpriteFactory.Instance.CreateGoriyaWalkSouthSprite();
            delay_frame_index = 0;

        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (goriya.xPos == 450 && goriya.yPos == 150)
            {
                goriya.currentState = new GoriyaUseItem(goriya, Entities.Facing.Left);
            }
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.yPos += 5;
                sprite.Update();
            }
        }
    }
}
