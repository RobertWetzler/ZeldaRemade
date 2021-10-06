using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.BigJelly
{
    class BigJellyWalkSouth : INPCState
    {
        private IEnemySprite sprite;
        private int delay_frame_index;
        private BigJelly bigjelly;

        private static int delay_frames = 10;


        public BigJellyWalkSouth(BigJelly bigjelly)
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
            if (bigjelly.xPos == 450 && bigjelly.yPos == 150)
            {
                bigjelly.currentState = new BigJellyWalkWest(bigjelly);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bigjelly.yPos += 5;
                sprite.Update();
            }
        }
    }
}