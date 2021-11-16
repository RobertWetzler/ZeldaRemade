using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project.Sprites.ItemSprites
{
    class LeftDownFireballSprite : IProjectileSprite
    {
        private Texture2D dragonSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int delay_frame_index;
        private static int delay_frames = 5;
        private int currentFrame = 0;
        private Vector2 position;
        private Vector2 startPosition;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public LeftDownFireballSprite(Texture2D dragonSpriteSheet, List<Rectangle> sourceFrames, Vector2 position)
        {
            this.dragonSpriteSheet = dragonSpriteSheet;
            this.sourceFrames = sourceFrames;
            this.position = position;
            startPosition = position;
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle((int)position.X, (int)position.Y, source.Width * 4, source.Height * 4);
            spriteBatch.Draw(dragonSpriteSheet, destRectangle, source, Color.White);
        }

        public bool IsFinished()
        {
            bool isFinished = false;

            if ((int)(this.startPosition.X - this.position.X) > 200)
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
                position.X -= 5;
                position.Y += 5;
                currentFrame++;
                currentFrame %= sourceFrames.Count;
            }
        }
   
    }
}
