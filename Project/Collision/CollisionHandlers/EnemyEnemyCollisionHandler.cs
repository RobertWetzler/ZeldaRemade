using Microsoft.Xna.Framework;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class EnemyEnemyCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable enemyCollidable2, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            IEnemy enemy2 = enemyCollidable2 as IEnemy;
            int dx = 0;
            int dy = 0;
            switch (side)
            {
                case CollisionSide.Up:
                    dy = enemy2.BoundingBox.Bottom - enemy.BoundingBox.Top;
                    enemy.ChangeDirection(EnemyDirections.South);
                    enemy2.ChangeDirection(EnemyDirections.North);
                    break;
                case CollisionSide.Down:
                    dy = enemy2.BoundingBox.Top - enemy.BoundingBox.Bottom;
                    enemy.ChangeDirection(EnemyDirections.North);
                    enemy2.ChangeDirection(EnemyDirections.South);
                    break;
                case CollisionSide.Left:
                    dx = enemy2.BoundingBox.Right - enemy.BoundingBox.Left;
                    enemy.ChangeDirection(EnemyDirections.East);
                    enemy2.ChangeDirection(EnemyDirections.West);
                    break;
                case CollisionSide.Right:
                    dx = enemy2.BoundingBox.Left - enemy.BoundingBox.Right;
                    enemy.ChangeDirection(EnemyDirections.West);
                    enemy2.ChangeDirection(EnemyDirections.East);
                    break;
            }
            enemy.Position = new Vector2(enemy.Position.X + dx, enemy.Position.Y + dy);
        }
    }
}
