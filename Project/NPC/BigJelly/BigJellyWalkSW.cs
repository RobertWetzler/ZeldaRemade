using Project.NPC.Skeleton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project;
using Project.Factory;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkSW : INPCState
    {
        
        private int delay_frame_index;
        private BigJelly bigjelly;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public BigJellyWalkSW(BigJelly bigjelly)
        {
            this.bigjelly = bigjelly;
            sprite = NPCSpriteFactory.Instance.CreateBigJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (bigjelly.xPos == 350 && bigjelly.yPos == 50)
            {
                bigjelly.currentState = new BigJellyWalkSE(bigjelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bigjelly.yPos += 5;
                bigjelly.xPos -= 5;
                sprite.Update();
            }
        }
    }
}