using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class WallMaster : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;
        public WallMaster()
        {
            xPos = 400;
            yPos = 100;
            currentState = new WallMasterWalkEast(this);
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
