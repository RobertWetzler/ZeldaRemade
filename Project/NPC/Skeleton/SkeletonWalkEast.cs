using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.Skeleton
{
    class SkeletonWalkEast : INPCState
    {
        private int delay_frame_index;
        private Skeleton skeleton;

        private static int delay_frames = 10;
        private IEnemySprite sprite;



        public SkeletonWalkEast(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            sprite = NPCSpriteFactory.Instance.CreateSkeletonSprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (skeleton.xPos == 450 && skeleton.yPos == 100)
            {
                skeleton.currentState = new SkeletonWalkSouth(skeleton);
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