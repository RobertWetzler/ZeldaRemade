using Project.NPC.Bat;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Project;
using Project.Factory;

namespace Project.NPC.Bat
{
    class BatWalkNorth : INPCState
    {
        private int my_frame_index;
        private int delay_frame_index;
        private Bat bat;

        private static int delay_frames = 5;
        private static List<Rectangle> my_source_frames = new List<Rectangle>{
           NPCSpriteFactory.BAT_1,
           NPCSpriteFactory.BAT_2
        };

        public BatWalkNorth(Bat bat)
        {
            this.bat = bat;
            my_frame_index = 0;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Texture2D texture = NPCSpriteFactory.Instance.GetBatSpriteSheet();
            Rectangle source = my_source_frames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(texture, destination, source, Color.White);
        }

        public void Update()
        {
            if (bat.xPos == 400 && bat.yPos == 100)
            {
                bat.currentState = new BatWalkNW(bat);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                bat.yPos -= 5;
                my_frame_index++;
                my_frame_index %= my_source_frames.Count;
            }
        }
    }
}