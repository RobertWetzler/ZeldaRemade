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


        public OldMan(Vector2 pos)
        {
            font = FontFactory.Instance.GetOldManMessage();
            this.pos = pos;
            currentState = new OldManStill(this);

        }

        public Rectangle BoundingBox => currentState.Sprite.DestRectangle;

        public void Draw(SpriteBatch spriteBatch)
        {
            currentState.Draw(spriteBatch, pos);
            spriteBatch.DrawString(font, message, new Vector2(250, 150), Color.White);

        }


        public void Update(GameTime gameTime)
        {
            currentState.Update(gameTime);
        }
    }

}
