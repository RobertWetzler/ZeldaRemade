using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project.NPC.Snake
{
    class SnakeWalkNorth : INPCState
    {
        private int delay_frame_index;
        private Snake snake;
        private IEnemySprite sprite;
        private static int delay_frames = 10;

        public SnakeWalkNorth(Snake snake)
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
            if (snake.xPos == 400 && snake.yPos == 100)
            {
                snake.currentState = new SnakeWalkEast(snake);
            }

            if (++delay_frame_index >= delay_frames)
            {
                delay_frame_index = 0;
                snake.yPos -= 5;
                sprite.Update();
            }
        }
    }
}