using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.Flame
{
    class Flame : INPC
    {
        public INPCState currentState;
        public Vector2 pos;

        public Flame(Vector2 pos)
        {
            this.pos = pos;
            currentState = new FlameStatic(this);

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
