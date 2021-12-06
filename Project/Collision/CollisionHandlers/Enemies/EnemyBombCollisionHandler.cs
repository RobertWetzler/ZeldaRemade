using Project.Projectiles;
using Project.Sprites.ItemSprites;
using System.Diagnostics;

namespace Project.Collision.CollisionHandlers.Enemies
{
    public class EnemyBombCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {

            IEnemy enemy = enemyCollidable as IEnemy;
            Bomb bomb = projectileCollidable as Bomb;

            if (bomb.IsExploding)
            {
                bomb.HasExploded = true;
                new EnemyProjectileCollisionHandler().HandleCollision(enemyCollidable, projectileCollidable, side);
            }
        }
    }
}
