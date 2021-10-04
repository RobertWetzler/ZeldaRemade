using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkEast : INPCState
    {
        private int delay_frame_index;
        private BigJelly bigjelly;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public BigJellyWalkEast(BigJelly bigjelly)
        {
            this.bigjelly = bigjelly;
            sprite = NPCSpriteFactory.Instance.CreateBigJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (bigjelly.xPos == 450 && bigjelly.yPos == 100)
            {
                bigjelly.currentState = new BigJellyWalkSouth(bigjelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bigjelly.xPos += 5;
                sprite.Update();
            }
        }
    }
}