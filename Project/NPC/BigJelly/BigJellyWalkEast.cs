using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkEast : INPCState
    {
        private int delay_frame_index;
        private BigJelly skeleton;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public BigJellyWalkEast(BigJelly skeleton)
        {
            this.skeleton = skeleton;
            sprite = NPCSpriteFactory.Instance.CreateBigJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (skeleton.xPos == 450 && skeleton.yPos == 100)
            {
                skeleton.currentState = new BigJellyWalkSouth(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.xPos += 5;
                sprite.Update();
            }
        }
    }
}