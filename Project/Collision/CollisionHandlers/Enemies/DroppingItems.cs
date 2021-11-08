using Project.Projectiles;
using Project.Items;
using Microsoft.Xna.Framework;
using System;

namespace Project.Collision.CollisionHandlers.Enemies
{
    class DroppingItems
    {
        /*private Random rand = new Random();
        private double randDouble;

        public DroppingItems() 
        {
            double randDouble = rand.NextDouble();
        }*/
        public static void ItemsDroppedBySkeleton(IItems item, Vector2 enemyPos, Random rand)
        {
            double randDouble = rand.NextDouble();
            if (randDouble < 0.1)
                item = new Fairy(enemyPos);
            else if (randDouble < 0.2)
                item = new Key(enemyPos);
            else if (randDouble < 0.6)
                item = new Heart(enemyPos);
            else 
                item = new OneRupee(enemyPos);
        }
        public static void ItemsDroppedByGoriya(IItems item, Vector2 enemyPos,Random rand)
        {
            double randDouble = rand.NextDouble();
            if (randDouble < 0.1)
                item = new Fairy(enemyPos);
            else if (randDouble < 0.2)
                item = new Key(enemyPos);
            else if (randDouble < 0.6)
                item = new OneRupee(enemyPos);
            else if (randDouble < 0.95)
                item = new Heart(enemyPos);
            else
                item = new BombItem(enemyPos);
        }
    }
}
