﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
            snake.XPos += (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * snake.Velocity);
        }

        public void UseWeapon()
        {
        }
    }
}