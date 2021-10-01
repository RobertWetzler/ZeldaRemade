using Project.NPC.Skeleton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project;
using Project.Factory;

namespace Project.NPC.Skeleton
{
    class SkeletonWalkSE : INPCState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Skeleton skeleton;

        private static int delay_frames = 10;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
            NPCSpriteFactory.SKELETON_1,
            NPCSpriteFactory.SKELETON_2

        };

        public SkeletonWalkSE(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NPCSpriteFactory.Instance.GetEnemySpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (skeleton.xPos == 350 && skeleton.yPos == 50)
            {
                skeleton.currentState = new SkeletonWalkEast(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.xPos += 5;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}