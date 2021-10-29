using Project.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    static class CollisionTypes
    {
        public static HashSet<Type> enemies = new HashSet<Type>
        {
            typeof(Bat),
            typeof(Dragon),
            typeof(SmallJelly),
            typeof(Goriya),
            typeof(Skeleton),
            typeof(WallMaster),
            typeof(Trap)
        };
        public static HashSet<Type> items = new HashSet<Type>
        {
            typeof(Key),
            typeof(Fairy),
            typeof(Triforce),
            typeof(BoomerangItem),
            typeof(ArrowItem),
            typeof(Heart),
            typeof(Map),
            typeof(Ring),
            typeof(Bow),
            typeof(HeartContainer),
            typeof(Flute),
            typeof(Meat),
            typeof(OneRupee),
            typeof(FiveRupee),
            typeof(BombItem),
            typeof(BlueArrowItem),
            typeof(BlueBoomerangItem),
            typeof(BlueBottle),
            typeof(BlueCandle),
            typeof(BlueRing),
            typeof(Bottle),
            typeof(Clock),
            typeof(Compass),
            typeof(SwordItem),
            typeof(WhiteSwordItem),
        };
    }
}
