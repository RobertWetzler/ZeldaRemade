using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Merchant

{
    class Merchant : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Merchant()
        {
            currentState = new MerchantStill(this);
            this.xPos = 400;
            this.yPos = 100;

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
