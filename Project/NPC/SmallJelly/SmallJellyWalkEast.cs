using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.SmallJelly
{
    class SmallJellyWalkEast : INPCState
    {
        private int delay_frame_index;
        private SmallJelly smalljelly;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public SmallJellyWalkEast(SmallJelly smalljelly)
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
            if (smalljelly.xPos == 450 && smalljelly.yPos == 100)
            {
                smalljelly.currentState = new SmallJellyWalkSouth(smalljelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                smalljelly.xPos += 5;
                sprite.Update();
            }
        }
    }
}