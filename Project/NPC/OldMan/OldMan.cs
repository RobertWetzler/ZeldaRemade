﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.OldMan
{
    class OldMan : INPC 
    {
        public INPCState currentState;
        public float xPos, yPos;

        public OldMan()
        {
            currentState = new OldManStill(this);
            this.xPos = 400;
            this.yPos = 100;
            
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        
        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }
    }
           
}