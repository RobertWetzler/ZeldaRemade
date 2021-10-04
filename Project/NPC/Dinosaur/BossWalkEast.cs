﻿using Project.NPC;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.Dinosaur
{
    class BossWalkEast : INPCState
    {

        private int delay_frame_index;
        private Boss boss;
        private IEnemySprite sprite;
        private static int delay_frames = 15;
       

        public BossWalkEast(Boss boss)
        {
            this.boss = boss;
            sprite = NPCSpriteFactory.Instance.CreateDinosaurSprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (boss.xPos == 448)
            {
                boss.currentState = new BossWalkWest(boss);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                boss.xPos += 3;
                sprite.Update();
            }
        }
    }
}