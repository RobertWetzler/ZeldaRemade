using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class GoriyaUseItem : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite goriyaSprite;
        private static int delay_frames = 7;
        private Facing dir;

        public GoriyaUseItem(Goriya goriya, Facing dir)
        {
            this.dir = dir;
            this.goriya = goriya;
            delay_frame_index = 0;
            goriyaSprite = NPCSpriteFactory.Instance.CreateGoriyaUseItemSprite(dir);
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            goriyaSprite.Draw(spriteBatch, xPos, yPos);            
        }

        public void Update(GameTime gameTime)
        {
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriyaSprite.Update();
            }          

        }
    }
}
