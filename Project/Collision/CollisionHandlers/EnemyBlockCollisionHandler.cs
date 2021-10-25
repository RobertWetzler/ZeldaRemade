using Microsoft.Xna.Framework;
using Project.Sprites.BlockSprites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class EnemyBlockCollisionHandler: ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable block, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            int dx = 0;
            int dy = 0;
            switch (side)
            {
                case CollisionSide.Up:
                    //Collided with top, move down
                    dy = block.BoundingBox.Bottom -enemy.BoundingBox.Top;
                    enemy.ChangeDirection(EnemyDirections.South);
                    break;
                case CollisionSide.Down:
                    //Collided with bottom, move up
                    dy = block.BoundingBox.Top - enemy.BoundingBox.Bottom;
                    enemy.ChangeDirection(EnemyDirections.North);
                    break;
                case CollisionSide.Left:
                    dx = block.BoundingBox.Right - enemy.BoundingBox.Left;
                    enemy.ChangeDirection(EnemyDirections.East);
                    break;
                case CollisionSide.Right:
                    dx = block.BoundingBox.Left - enemy.BoundingBox.Right;
                    enemy.ChangeDirection(EnemyDirections.West);
                    break;
            }
            enemy.Position = new Vector2(enemy.Position.X + dx, enemy.Position.Y + dy);
        }
    }
}
