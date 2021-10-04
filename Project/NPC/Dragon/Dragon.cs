using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Project.Sprites.ItemSprites;
using Project.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.NPC.Dragon
{
    class Dragon : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Dragon()
        {
            currentState = new DragonWalkLeft(this);
            xPos = 400;
            yPos = 300;
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
