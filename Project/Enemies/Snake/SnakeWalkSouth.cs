using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class SnakeWalkSouth : IEnemyState
    {
        private Snake snake;

        public SnakeWalkSouth(Snake snake)
        {
            this.snake = snake;
            this.snake.EnemySprite = NPCEnemySpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Right);
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    snake.SetState(new SnakeWalkEast(snake));
                    break;
                case EnemyDirections.North:
                    snake.SetState(new SnakeWalkNorth(snake));
                    break;
                case EnemyDirections.West:
                    snake.SetState(new SnakeWalkWest(snake));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            snake.YPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity);
        }

        public void UseWeapon()
        {
        }
    }
}