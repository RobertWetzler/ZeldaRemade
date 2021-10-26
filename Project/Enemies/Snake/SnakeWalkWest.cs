using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class SnakeWalkWest : IEnemyState
    {
        private Snake snake;

        public SnakeWalkWest(Snake snake)
        {
            this.snake = snake;
            this.snake.EnemySprite = EnemySpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Left);
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    snake.SetState(new SnakeWalkNorth(snake));
                    break;
                case EnemyDirections.South:
                    snake.SetState(new SnakeWalkSouth(snake));
                    break;
                case EnemyDirections.East:
                    snake.SetState(new SnakeWalkEast(snake));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            snake.Position = new Vector2(snake.Position.X + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity),
                                  snake.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}