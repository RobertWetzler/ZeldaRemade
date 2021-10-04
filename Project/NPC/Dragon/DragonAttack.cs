using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Dragon
{
    class DragonAttack : INPCState
    {
        private int delay_frame_index;
        private Dragon dragon;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public DragonAttack(Dragon dragon)
        {
            this.dragon = dragon;
            sprite = NPCSpriteFactory.Instance.CreateDragonAttackSprite();
            delay_frame_index = 0;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (++delay_frame_index >= delay_frames)
            {
                dragon.currentState = new DragonWalkRight(dragon);
            }
        }
    }
}
