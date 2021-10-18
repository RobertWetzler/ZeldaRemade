using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.OldMan
{
    class OldMan : INPC
    {
        public INPCState currentState;
        public Vector2 pos;

        public OldMan(Vector2 pos)
        {
            this.pos = pos;
            currentState = new OldManStill(this);

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
