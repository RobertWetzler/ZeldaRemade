using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Flame
{
    class Flame : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Flame()
        {
            xPos = 400;
            yPos = 100;
            currentState = new FlameStatic(this);

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
