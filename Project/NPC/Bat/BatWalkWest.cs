using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Bat
{
    class BatWalkWest : INPCState
    {

        private int delay_frame_index;
        private Bat bat;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public BatWalkWest(Bat bat)
        {
            this.bat = bat;
            sprite = NPCSpriteFactory.Instance.CreateBatSprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (bat.xPos == 400 && bat.yPos == 150)
            {
                bat.currentState = new BatWalkNorth(bat);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bat.xPos -= 5;
                sprite.Update();
            }
        }
    }
}