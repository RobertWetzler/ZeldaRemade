using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class GenericEnemySprite : ISprite
    {
        private int animationDelay; //animation speed
        private int animationCounter;
        private Texture2D spriteSheet;
        private List<Rectangle> sourceFrames;
        private int my_frame_index = 0;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;
        public GenericEnemySprite(Texture2D spriteSheet, List<Rectangle> sourceFrames)
        {
            this.spriteSheet = spriteSheet;
            this.sourceFrames = sourceFrames;
            animationCounter = 0;
            animationDelay = 100;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {

            Rectangle source = sourceFrames[my_frame_index];
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(spriteSheet, destRectangle, source, Color.White);
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
