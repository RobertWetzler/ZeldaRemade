using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Project.NPC.Skeleton
{
    class Skeleton : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;

        public Skeleton()
        {
            currentState = new SkeletonWalkEast(this);
            xPos = 400;
            yPos = 100;
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }
    }

}