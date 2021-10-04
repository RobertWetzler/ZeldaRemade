using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.Snake
{
    class SnakeWalkWest : INPCState
    {
        private int delay_frame_index;
        private Snake snake;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public SnakeWalkWest(Snake snake)
        {
            this.snake = snake;
            sprite = NPCSpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Left);
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (snake.xPos == 400 && snake.yPos == 150)
            {
                snake.currentState = new SnakeWalkNorth(snake);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                snake.xPos -= 5;
                sprite.Update();
            }
        }
    }
}