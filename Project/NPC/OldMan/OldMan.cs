using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

namespace Project.NPC.OldMan
{
    class OldMan : INPC
    {
        public INPCState currentState;
        public Vector2 pos;
        private SpriteFont font;
        private string message = "EASTMOST PENNINSULA IS THE SECRET";
        private int timeToSpawn, startTime;

        public OldMan(Vector2 pos)
        {
            font = FontFactory.Instance.GetOldManMessage();
            this.pos = pos;
            startTime = 0;
            timeToSpawn = 600;
            currentState = new NPCSpawning();

        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            
            spriteBatch.DrawString(font, message, new Vector2(250, 150), Color.White);
            
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
                    currentState = new OldManStill(this);
                }
            }
        }
    }

}
