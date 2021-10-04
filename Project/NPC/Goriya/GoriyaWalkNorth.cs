using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class GoriyaWalkNorth : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public GoriyaWalkNorth(Goriya goriya)
        {
            this.goriya = goriya;
            sprite = NPCSpriteFactory.Instance.CreateGoriyaWalkNorthSprite();
            delay_frame_index = 0;

        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (goriya.xPos == 400 && goriya.yPos == 100)
            {
                goriya.currentState = new GoriyaUseItem(goriya, Entities.Facing.Right);
            }
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriya.yPos -= 5;
                sprite.Update();
            }
        }
    }
}
