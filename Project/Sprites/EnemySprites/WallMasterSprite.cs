using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project
{
    class WallMasterSprite : IEnemySprite
    {
        private Texture2D spriteSheet;
        private List<Rectangle> sourceFrames;
        private int my_frame_index = 0;
        SpriteEffects spriteEffects;
        public WallMasterSprite(Texture2D spriteSheet, List<Rectangle> sourceFrames, Facing dir)
        {
            this.spriteSheet = spriteSheet;
            this.sourceFrames = sourceFrames;
            switch (dir)
            {
                case Facing.Right:
                    spriteEffects = SpriteEffects.None;
                    break;
                case Facing.Left:
                    spriteEffects = SpriteEffects.FlipHorizontally;
                    break;
            }

        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            Rectangle source = sourceFrames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);

            spriteBatch.Draw(spriteSheet, destination, source, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
        }

        public void Update()
        {
            my_frame_index++;
            my_frame_index %= sourceFrames.Count;
        }
    }
}
