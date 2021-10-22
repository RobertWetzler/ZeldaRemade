using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project.NPC.Flame
{
    class Flame : INPC, ICollidable
    {
        public INPCState currentState;
        public float xPos, yPos;
        private int timeToSpawn, startTime;

        public Flame()
        {
            xPos = 400;
            yPos = 100;
            startTime = 0;
            timeToSpawn = 600;
            currentState = new NPCSpawning();
        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
            if (currentState is NPCSpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    currentState = new FlameStatic(this);
                }
            }
        }
    }
}
