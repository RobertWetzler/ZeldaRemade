using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using System.Collections.Generic;

namespace Project
{
    class WallMasterSprite : ISprite
    {
        private Texture2D spriteSheet;
        private List<Rectangle> sourceFrames;
        private int my_frame_index = 0;
        SpriteEffects spriteEffects;
        private int animationCounter = 0;
        private int animationDelay = 100;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
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
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[my_frame_index];
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                source.Width * 3, source.Height * 3);

            spriteBatch.Draw(spriteSheet, destRectangle, source, Color.White, 0f, Vector2.Zero, spriteEffects, 0f);
        }

        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                my_frame_index++;
                my_frame_index %= sourceFrames.Count;
            }
        }
    }
}
