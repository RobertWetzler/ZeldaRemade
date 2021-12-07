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
            else if (randDouble < 0.2)
                item = new Fairy(enemyPos);
            else if (randDouble < 0.6)
                item = new Heart(enemyPos);
            else
                item = new OneRupee(enemyPos);


            if (projectile.IsFriendly)
            {
                if (!(enemy is Trap) && !(enemy is Dinosaur))
                {
                    if (projectile is Arrow)
                    {
                        enemy.TakeDamage(2);
                    }
                    else if (projectile is Bomb || projectile is BlueArrow)
                    {
                        enemy.TakeDamage(4);
                    }
                    else if (projectile is Boomerang || projectile is BlueBoomerang)
                    {
                        if (enemy is Bat || enemy is SmallJelly || enemy is BigJelly)
                        {
                            enemy.TakeDamage(1);
                        }
                        else
                        {
                            enemy.TakeDamage(0); //Boomerang only stuns large enemies
                        }
                    }
                    else
                    {
                        enemy.TakeDamage(1);
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
                else if (enemy is Dinosaur)
                {
                    if (projectile is Bomb)
                    {
                        enemy.TakeDamage(1);
                    }

                    if (enemy.Health.CurrentHealth == 0)
                    {
                        enemy.Despawn();
                    }
                }
            }
        }
    }
}
