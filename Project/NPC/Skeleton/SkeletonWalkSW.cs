﻿using Project.NPC.Skeleton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project;
using Project.Factory;

namespace Project.NPC.Skeleton
{
    class SkeletonWalkSW : INPCState
    {
        
        private int delay_frame_index;
        private Skeleton skeleton;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public SkeletonWalkSW(Skeleton skeleton)
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
            if (skeleton.xPos == 350 && skeleton.yPos == 50)
            {
                skeleton.currentState = new SkeletonWalkSE(skeleton);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                skeleton.yPos += 5;
                skeleton.xPos -= 5;
                sprite.Update();
            }
        }
    }
}