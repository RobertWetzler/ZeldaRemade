using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class GoriyaWalkEast : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public GoriyaWalkEast(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = NPCSpriteFactory.Instance.CreateGoriyaWalkEastSprite();
            delay_frame_index = 0;

        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (goriya.xPos == 450 && goriya.yPos == 100)
            {
                goriya.currentState = new GoriyaWalkSouth(goriya);
            }
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.xPos += 5;
                sprite.Update();
            }
        }
    }
}
