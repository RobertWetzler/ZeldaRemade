using Microsoft.Xna.Framework;
using Project.Items;
using Project.Projectiles;
using System;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        private IItems item;
        private Vector2 enemyPos;
        private Random rand = new Random();
        private double randDouble;

        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            IProjectile projectile = projectileCollidable as IProjectile;
            enemyPos = new Vector2(enemyCollidable.BoundingBox.X, enemyCollidable.BoundingBox.Y);

            randDouble = rand.NextDouble();
            if (randDouble < 0.05)
                item = new BombItem(enemyPos);
            else if (randDouble < 0.07)
                item = new Compass(enemyPos);
            else if (randDouble < 0.12)
                item = new Key(enemyPos);
            else if (randDouble < 0.18)
                item = new Fairy(enemyPos);
            else if (randDouble < 0.42)
                item = new Heart(enemyPos);
            else
                item = new OneRupee(enemyPos);

            if (projectile.IsFriendly)
            {
                if (!(enemy is Trap))
                {
                    if (item is Arrow)
                    {
                        enemy.Health.DecreaseHealth(2);
                    }
                    else
                    {
                        enemy.Health.DecreaseHealth(1);
                    }
                    if (enemy.Health.CurrentHealth == 0)
                    {
                        enemy.Despawn();
                        if (enemy is Goriya || enemy is Skeleton || enemy is WallMaster)
                        {
                            randDouble = rand.NextDouble();
                            if (randDouble > 0.65)
                                enemy.DropItem(item);
                        }
                    }
                }

            }
        }
    }
}
