using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using System.Collections.Generic;

namespace Project.NPC.Snake
{
    class SnakeWalkEast : INPCState
    {
        private int delay_frame_index;
        private Snake snake;
        private static int delay_frames = 10;
        private IEnemySprite sprite;
        

        public SnakeWalkEast(Snake snake)
        {
            this.snake = snake;
            sprite = NPCSpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Right);
            delay_frame_index = 0;
        }

        public void Draw(SpriteBatch spriteBatch, float xPos, float yPos)
        {
            sprite.Draw(spriteBatch, xPos, yPos);
        }

        public void Update(GameTime gameTime)
        {
            if (snake.xPos == 450 && snake.yPos == 100)
            {
                snake.currentState = new SnakeWalkSouth(snake);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                snake.xPos += 5;
                sprite.Update();
            }
        }
    }
}

