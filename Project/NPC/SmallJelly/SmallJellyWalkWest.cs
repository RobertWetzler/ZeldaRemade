using Project.NPC.Skeleton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project.Factory;

namespace Project.NPC.SmallJelly
{
    class SmallJellyWalkWest : INPCState
    {
        
        private int delay_frame_index;
        private SmallJelly skeleton;
        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public SmallJellyWalkWest(SmallJelly skeleton)
        {
            this.skeleton = skeleton;
            sprite = NPCSpriteFactory.Instance.CreateSmallJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (skeleton.xPos == 400 && skeleton.yPos == 150)
            {
                skeleton.currentState = new SmallJellyWalkNorth(skeleton);
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
