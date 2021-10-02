using Project.NPC.Skeleton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project.Factory;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkWest : INPCState
    {
        
        private int delay_frame_index;
        private BigJelly skeleton;
        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public BigJellyWalkWest(BigJelly skeleton)
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
            if (skeleton.xPos == 400 && skeleton.yPos == 150)
            {
                skeleton.currentState = new BigJellyWalkNorth(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.xPos -= 5;
                sprite.Update();
            }
        }
    }
}
