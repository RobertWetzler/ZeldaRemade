using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.NPC.Bat
{
    class Bat : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Bat()
        {
            currentState = new BatWalkEast(this);
            xPos = 400;
            yPos = 100;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}