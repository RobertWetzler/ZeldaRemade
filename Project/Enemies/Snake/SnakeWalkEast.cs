using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class SnakeWalkEast : IEnemyState
    {
        private Snake snake;

        public SnakeWalkEast(Snake snake)
        {
            this.snake = snake;
            this.snake.EnemySprite = EnemySpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Right);
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
                case EnemyDirections.West:
                    snake.SetState(new SnakeWalkWest(snake));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            snake.Position = new Vector2(snake.Position.X + (float)(gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity),
                                    snake.Position.Y);
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}

