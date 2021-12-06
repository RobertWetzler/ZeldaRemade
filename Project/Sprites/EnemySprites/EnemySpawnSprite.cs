using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Project
{
    class EnemySpawnSprite : ISprite
    {
        private Texture2D bombSpriteSheet;
        private List<Rectangle> sourceFrames;
        private int currentFrame = 0;
        private int animationCounter = 0;
        private int animationDelay = 200;
        private Rectangle destRectangle;
        public Rectangle DestRectangle => destRectangle;

        public EnemySpawnSprite(Texture2D bombSpriteSheet, List<Rectangle> sourceFrames)
        {
            this.bombSpriteSheet = bombSpriteSheet;
            this.sourceFrames = sourceFrames;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            Rectangle source = sourceFrames[currentFrame];
            destRectangle = new Rectangle(
                (int)position.X, (int)position.Y,
                source.Width * 3, source.Height * 3);
            spriteBatch.Draw(bombSpriteSheet, destRectangle, source, color);
        }

        public void Update(GameTime gameTime)
        {
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                currentFrame++;
                currentFrame %= sourceFrames.Count;
            }
        }
    }
}
