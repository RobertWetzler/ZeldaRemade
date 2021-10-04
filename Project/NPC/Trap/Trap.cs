using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Trap
{
    class Trap : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Trap()
        {
            currentState = new TrapStill(this);
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
