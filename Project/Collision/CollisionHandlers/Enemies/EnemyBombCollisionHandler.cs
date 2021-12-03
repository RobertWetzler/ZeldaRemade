using Project.Projectiles;

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
                enemy.Health.DecreaseHealth(10);
                new EnemyProjectileCollisionHandler().HandleCollision(enemyCollidable, projectileCollidable, side);
            }
        }
    }
}
