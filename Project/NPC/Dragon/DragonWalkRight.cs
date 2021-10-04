using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Dragon
{
    class DragonWalkRight : INPCState
    {
        private int delay_frame_index;
        private Dragon dragon;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public DragonWalkRight(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = NPCSpriteFactory.Instance.CreateDragonWalkSprite();
            delay_frame_index = 0;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (dragon.xPos == 400 && dragon.yPos == 300)
            {
                dragon.currentState = new DragonWalkLeft(dragon);
            }
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                dragon.xPos += 5;
                sprite.Update();
            }
        }
    }
}
