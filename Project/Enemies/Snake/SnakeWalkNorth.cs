using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class SnakeWalkNorth : IEnemyState
    {

        private Snake snake;

        public SnakeWalkNorth(Snake snake)
        {
            this.snake = snake;
            this.snake.EnemySprite = NPCEnemySpriteFactory.Instance.CreateSnakeSprite(Entities.Facing.Left);
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    snake.SetState(new SnakeWalkEast(snake));
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
            snake.YPos += (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity);
        }

        public void UseWeapon()
        {
        }
    }
}