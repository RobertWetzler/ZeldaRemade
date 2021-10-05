using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Entities;

namespace Project.Sprites.ItemSprites
{
    class LeftUpFireballSprite : IWeaponSprite
    {
        private Texture2D dragonSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int delay_frame_index;
        private static int delay_frames = 5;
        private int currentFrame = 0;
        private Vector2 position;

        public LeftUpFireballSprite(Texture2D dragonSpriteSheet, List<Rectangle> sourceFrames, Vector2 position)
        {
            this.dragonSpriteSheet = dragonSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.position = position;
            delay_frame_index = 0;
    }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle source = sourceFrames[currentFrame];
            Rectangle destination = new Rectangle((int)position.X, (int)position.Y, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dragonSpriteSheet, destination, source, Color.White);
        }

        public bool isFinished()
        {
            bool isFinished = false;

            if (this.position.X == 250)
            {
                isFinished = true;
            }
            return isFinished;
        }

        public void Update(GameTime gameTime)
        {
            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                position.X-=5;
                position.Y-=5;
                currentFrame++;
                currentFrame %= sourceFrames.Count;
            }
        }
    }
}
