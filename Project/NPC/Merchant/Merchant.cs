using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Project.NPC.Merchant
{
    class Merchant : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Merchant()
        {
            this.xPos = 400;
            this.yPos = 100;

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }


        public void Update()
        {
            currentState.Update();
        }
    }

}