using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.NPC.Flame
{
    class Flame : INPC, ICollidable
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Flame()
        {
            xPos = 400;
            yPos = 100;
            currentState = new FlameStatic(this);

        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;

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
