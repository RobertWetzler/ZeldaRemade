using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Goriya
{
    class Goriya : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Goriya()
        {
            xPos = 400;
            yPos = 100;
            currentState = new GoriyaUseItem(this, Entities.Facing.Right);

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
