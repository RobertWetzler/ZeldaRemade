using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            snake.XPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity);
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}

