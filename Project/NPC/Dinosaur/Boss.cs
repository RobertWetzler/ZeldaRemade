using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Dinosaur
{
    class Boss : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Boss()
        {
            currentState = new BossWalkEast(this);
            xPos = 400;
            yPos = 100;
        }

        public void Update()
        {
            currentState.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}