using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.SmallJelly
{
    class SmallJellyWalkSW : INPCState
    {

        private int delay_frame_index;
        private SmallJelly smalljelly;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public SmallJellyWalkSW(SmallJelly smalljelly)
        {
            this.smalljelly = smalljelly;
            sprite = NPCSpriteFactory.Instance.CreateSmallJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (smalljelly.xPos == 350 && smalljelly.yPos == 50)
            {
                smalljelly.currentState = new SmallJellyWalkSE(smalljelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                smalljelly.yPos += 5;
                smalljelly.xPos -= 5;
                sprite.Update();
            }
        }
    }
}