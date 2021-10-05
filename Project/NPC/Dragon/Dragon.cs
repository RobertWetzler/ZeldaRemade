using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

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
