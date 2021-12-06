using Microsoft.Xna.Framework;

namespace Project.Collision.CollisionHandlers
{
    class EnemyBlockCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable block, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            if (!(enemy is Goriya && ((Goriya)enemy).CurrentState is GoriyaUseItem) && !(enemy is Trap))
            {
                switch (side)
                {
                    case CollisionSide.Up:
                        //Collided with top, move down
                        enemy.ChangeDirection(EnemyDirections.South);
                        break;
                    case CollisionSide.Down:
                        //Collided with bottom, move up
                        enemy.ChangeDirection(EnemyDirections.North);
                        break;
                    case CollisionSide.Left:
                        enemy.ChangeDirection(EnemyDirections.East);
                        break;
                    case CollisionSide.Right:
                        enemy.ChangeDirection(EnemyDirections.West);
                        break;
                }
            }
            
        }
    }
}
