using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.NPC.OldMan
{
    class OldMan : INPC, ICollidable
    {
        public INPCState currentState;
        public Vector2 pos;

        public OldMan(Vector2 pos)
        {
            this.pos = pos;
            currentState = new OldManStill(this);

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
