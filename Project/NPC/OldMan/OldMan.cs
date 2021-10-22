using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.NPC.OldMan
{
    class OldMan : INPC
    {
        public INPCState currentState;
        public float xPos, yPos;
        private int timeToSpawn, startTime;

        public OldMan()
        {
            this.xPos = 400;
            this.yPos = 100;
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
                    currentState = new OldManStill(this);
                }
            }
        }
    }

}
