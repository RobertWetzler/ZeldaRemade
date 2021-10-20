using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class GenericEnemySprite : IEnemySprite
    {
        private int animationDelay; //animation speed
        private int animationCounter;
        private Texture2D spriteSheet;
        private List<Rectangle> sourceFrames;
        private int my_frame_index = 0;

        public GenericEnemySprite(Texture2D spriteSheet, List<Rectangle> sourceFrames)
        {
            this.spriteSheet = spriteSheet;
            this.sourceFrames = sourceFrames;
            animationCounter = 0;
            animationDelay = 100;
        }
        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {

            Rectangle source = sourceFrames[my_frame_index];
            Rectangle destination = new Rectangle(
                (int)xPos, (int)yPos,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(spriteSheet, destination, source, Color.White);
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
