using Microsoft.Xna.Framework;
using Project.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project.NPC.Flame;
using Project.NPC.OldMan;
using Project.Items;
using Project.Collision.CollisionHandlers;
using Project.Sprites.BlockSprites;
using Project.Blocks;
using Project.Projectiles;
using Project.Blocks.MovableBlock;


namespace Project.Collision
{
    class AllCollisionHandler: ICollisionHandler
    {
        private Dictionary<Tuple<Type, Type>, ICollisionHandler> commandMap;
        public AllCollisionHandler()
        {
            commandMap = new Dictionary<Tuple<Type, Type>, ICollisionHandler>();
            BuildDictionary();
        }

        private void BuildDictionary()
        {
            Type playerType = typeof(GreenLink);

            //Enemy Types
            Type batType = typeof(Bat);
            Type bossType = typeof(Dragon);
            Type gelType = typeof(SmallJelly);
            Type goriyaType = typeof(Goriya);
            Type skeletonType = typeof(Skeleton);
            Type wallmasterType = typeof(WallMaster);
            Type trapType = typeof(Trap);
            Type[] enemyTypes = { batType, bossType, gelType, goriyaType, skeletonType, wallmasterType, trapType };

            // Projectile Types
            Type[] projectileTypes = { typeof(Arrow), typeof(BlueArrow), typeof(BlueBoomerang), typeof(Boomerang), 
                typeof(Bomb), typeof(Projectiles.Flame), typeof(Sword)};

            //Block Types
            Type[] blockTypes = { typeof(BlackBlock), typeof(BlueBlock), typeof(BrickBlock), 
            typeof(DottedBlock), typeof(LayeredBlock), typeof(LeftFacingDragonBlock), 
            typeof(PlainBlock), typeof(PyramidBlock), typeof(Rectangle1), typeof(Rectangle2), typeof(RightFacingDragonBlock)};

            //Item Types
            Type keyType = typeof(Key);
            Type fairyType = typeof(Fairy);
            Type triforceType = typeof(Triforce);
            Type boomerangType = typeof(BoomerangItem);
            Type arrowType = typeof(ArrowItem);
            Type heartType = typeof(Heart);
            Type mapType = typeof(Map);
            Type ringType = typeof(Ring);
            Type bowType = typeof(Bow);
            Type heartcontainerType = typeof(HeartContainer);
            Type fluteType = typeof(Flute);
            Type meatType = typeof(Meat);
            Type onerupeeType = typeof(OneRupee);
            Type fiverupeeType = typeof(FiveRupee);
            Type bombitemType = typeof(BombItem);
            Type bluearrowType = typeof(BlueArrowItem);
            Type blueboomerangType = typeof(BlueBoomerangItem);
            Type bluebottleType = typeof(BlueBottle);
            Type bluecandleType = typeof(BlueCandle);
            Type blueringType = typeof(BlueRing);
            Type bottleType = typeof(Bottle);
            Type clockType = typeof(Clock);
            Type compassType = typeof(Compass);
            Type swordType = typeof(SwordItem);
            Type whiteswordType = typeof(WhiteSwordItem);

            Type[] itemTypes = { keyType, fairyType, triforceType, boomerangType, arrowType, heartType, mapType, ringType, bowType,
            heartcontainerType, fluteType, meatType, onerupeeType, fiverupeeType, bombitemType, bluearrowType, blueboomerangType,
            bluebottleType, bluecandleType, blueringType, bottleType, clockType, compassType, swordType, whiteswordType };

            Type oldmanType = typeof(OldMan);
            Type flameType = typeof(NPC.Flame.Flame);
            Type[] npcTypes = { oldmanType, flameType };


            foreach (Type blockType in blockTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, blockType), new PlayerBlockCollisionHandler());
                foreach(Type enemyType in enemyTypes)
                {
                    commandMap.Add(new Tuple<Type, Type>(enemyType, blockType), new EnemyBlockCollisionHandler());
                }
            }
            commandMap.Add(new Tuple<Type, Type>(typeof(MovableBlock), playerType), new MovableBlockPlayerCollisionHandler());
            
            foreach (Type enemyType in enemyTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, enemyType), new PlayerEnemyCollisionHandler());
        
            }

            foreach (Type npcType in npcTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, npcType), new PlayerNPCCollisionHandler());
            }


            foreach (Type projectileType in projectileTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, projectileType), new PlayerProjectileCollisionHandler());
                commandMap.Add(new Tuple<Type, Type>(projectileType, playerType), new ProjectileAnyCollisionHandler());
                foreach (Type enemyType in enemyTypes)
                {
                    commandMap.Add(new Tuple<Type, Type>(projectileType, enemyType), new ProjectileAnyCollisionHandler());
                }
                foreach (Type blockType in blockTypes)
                {
                    commandMap.Add(new Tuple<Type, Type>(projectileType, blockType), new ProjectileAnyCollisionHandler());
                }
            }
            foreach(Type itemType in itemTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(itemType, playerType), new ItemPlayerCollisionHandler());
            }
        }


        public void HandleCollision(ICollidable collidee, ICollidable collider, CollisionSide side)
        {
            Tuple<Type, Type> key = new Tuple<Type, Type>(collidee.GetType(), collider.GetType());
            if (commandMap.ContainsKey(key))
            {
                ICollisionHandler handler = commandMap[key];
                handler.HandleCollision(collidee, collider, side);
            }
        }
    }
}