using Project.Projectiles;

namespace Project.Collision.CollisionHandlers.Enemies
{
    public class EnemyBombCollisionHandler : ICollisionHandler
    {
        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {

            Bomb bomb = projectileCollidable as Bomb;

            if (bomb.IsExploding)
            {
                new EnemyProjectileCollisionHandler().HandleCollision(enemyCollidable, projectileCollidable, side);
            }
        }
    }
}
