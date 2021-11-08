using Project.Projectiles;
using Project.Items;
using Microsoft.Xna.Framework;
using System;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class EnemyProjectileCollisionHandler : ICollisionHandler
    {
        private IItems item;
        private Vector2 enemyPos;
        private Random rand = new Random();
        // private DroppingItems itemsBySkeleton, itemsByGoriya;

        public void HandleCollision(ICollidable enemyCollidable, ICollidable projectileCollidable, CollisionSide side)
        {
            IEnemy enemy = enemyCollidable as IEnemy;
            IProjectile projectile = projectileCollidable as IProjectile;
            enemyPos = new Vector2(enemyCollidable.BoundingBox.X, enemyCollidable.BoundingBox.Y);

            // generate random item
            // itemsBySkeleton.ItemsDroppedBySkeleton(item, enemyPos);
            //itemsByGoriya.ItemsDroppedByGoriya(item, enemyPos);
            //itemsBySkeleton = new DroppingItems();
            //itemsByGoriya = new DroppingItems();
            //item = new Fairy(enemyPos);
            
            double randDouble = rand.NextDouble();
            if (randDouble < 0.1)
                item = new Fairy(enemyPos);
            else if (randDouble < 0.2)
                item = new Key(enemyPos);
            else if (randDouble < 0.6)
                item = new Heart(enemyPos);
            else
                item = new OneRupee(enemyPos);

            if (projectile.IsFriendly)
            {
                if (!(enemy is Trap))
                {
                    enemy.Despawn();
                    /*if (enemy is Skeleton || enemy is WallMaster)
                    {
                        itemsBySkeleton.ItemsDroppedBySkeleton(item, enemyPos);
                        enemy.DropItem(item);
                    }*/
                    if (enemy is Goriya)
                    {
                        //DroppingItems.ItemsDroppedByGoriya(item, enemyPos, rand);
                        enemy.DropItem(item);
                    }

                    /*switch (enemy) {
                        case Skeleton:
                            break;
                            }*/
                }

            }
        }
    }
}
