
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkSE : INPCState
    {

        private int delay_frame_index;
        private BigJelly bigjelly;

        private static int delay_frames = 10;
        private IEnemySprite sprite;

        public BigJellyWalkSE(BigJelly bigjelly)
        {
            this.bigjelly = bigjelly;
            sprite = NPCSpriteFactory.Instance.CreateBigJellySprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (bigjelly.xPos == 400 && bigjelly.yPos == 100)
            {
                bigjelly.currentState = new BigJellyWalkEast(bigjelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bigjelly.yPos += 5;
                bigjelly.xPos += 5;
                sprite.Update();
            }
        }
    }
}