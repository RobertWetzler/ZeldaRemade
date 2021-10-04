using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Dragon
{
    class Dragon : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;
        public bool attack = false;

        public Dragon()
        {
            currentState = new DragonWalkLeft(this);
            xPos = 400;
            yPos = 300;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);

            if (attack)
            {
                //
            }
        }

        public void Update()
        {
            currentState.Update();
        }
    }
}
