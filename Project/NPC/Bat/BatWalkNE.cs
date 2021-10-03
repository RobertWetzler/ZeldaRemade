using Project.NPC.Bat;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project.Factory;

namespace Project.NPC.Bat
{
    class BatWalkNE : INPCState
    {
        private int delay_frame_index;
        private IEnemySprite sprite;
        private Bat bat;

        private static int delay_frames = 10;

        public BatWalkNE(Bat bat)
        {
            this.bat = bat;
            sprite = NPCSpriteFactory.Instance.CreateBatSprite();
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update()
        {
            if (bat.xPos == 400 && bat.yPos == 0)
            {
                bat.currentState = new BatWalkSW(bat);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bat.yPos -= 5;
                bat.xPos += 5;
                sprite.Update();
            }
        }
    }
}