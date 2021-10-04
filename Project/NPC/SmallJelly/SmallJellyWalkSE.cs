
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project;
using Project.Factory;

namespace Project.NPC.SmallJelly
{
    class SmallJellyWalkSE : INPCState
    {
        
        private int delay_frame_index;
        private SmallJelly smalljelly;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public SmallJellyWalkSE(SmallJelly smalljelly)
        {
            this.smalljelly = smalljelly;
            sprite = NPCSpriteFactory.Instance.CreateSmallJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (smalljelly.xPos == 400 && smalljelly.yPos == 100)
            {
                smalljelly.currentState = new SmallJellyWalkEast(smalljelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                smalljelly.yPos += 5;
                smalljelly.xPos += 5;
                sprite.Update();
            }
        }
    }
}