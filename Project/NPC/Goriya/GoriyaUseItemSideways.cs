using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Goriya
{
    class GoriyaUseItemSideways : INPCState
    {
        private int delay_frame_index;
        private Goriya goriya;
        private IEnemySprite goriyaSprite;
 
        private static int delay_frames = 10;
        private bool faceRight;
        public GoriyaUseItemSideways(Goriya goriya, bool faceRight)
        {
            this.faceRight = faceRight;
            this.goriya = goriya;
            delay_frame_index = 0;
            
            goriyaSprite = NPCSpriteFactory.Instance.CreateGoriyaUseItemSidewaysSprite(faceRight);
           
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            goriyaSprite.Draw(spriteBatch, xPos, yPos);
          
        }

        public void Update()
        {

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                goriyaSprite.Update();
                

            }
            

        }
    }
}
