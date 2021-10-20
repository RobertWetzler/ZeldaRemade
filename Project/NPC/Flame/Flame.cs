using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.NPC.Flame
{
    class Flame : INPC, ICollidable
    {
        public INPCState currentState;
        public Vector2 pos;

        public Flame(Vector2 pos)
        {
            this.pos = pos;
            currentState = new FlameStatic(this);

        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;

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
