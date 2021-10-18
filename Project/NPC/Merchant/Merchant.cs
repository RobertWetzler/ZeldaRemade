using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Project.NPC.Merchant

{
    class Merchant : INPC
    {
        public INPCState currentState;
        public Vector2 pos;

        public Merchant(Vector2 pos)
        {
            this.pos = pos;
            currentState = new MerchantStill(this);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, pos);
        }


        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }
    }

}
