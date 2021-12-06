using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Shading;

namespace Project.NPC.Flame
{
    class Flame : FireLight, INPC
    {
        public INPCState currentState;
        public Vector2 pos;
        private int timeToSpawn, startTime;

        public Flame(Vector2 pos)
        {
            this.pos = pos;
            startTime = 0;
            timeToSpawn = 600;
            currentState = new NPCSpawning();
        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.NPC;

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, pos);
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
