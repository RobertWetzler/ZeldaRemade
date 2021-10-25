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
using Project.NPC;
using Project.Items;
using Project.Collision.CollisionHandlers;
using Project.Sprites.BlockSprites;
using Project.Blocks;
using Project.Blocks.MovableBlock;

namespace Project.Collision
{
    class AllCollisionHandler
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
            Type[] enemyTypes = { batType, bossType, gelType, goriyaType, skeletonType };

            //Object Types
            Type boomerangType = typeof(Boomerang);
            Type bombType = typeof(Bomb);
            Type bowType = typeof(Bow);
            Type[] objectTypes = { boomerangType, bowType, bombType };

            // Weapon Types
            Type[] weaponTypes = { typeof(Sword), typeof(Boomerang), typeof(Bomb), typeof(Bow) };

            //Block Types
            Type[] blockTypes = { typeof(BlackBlock), typeof(BlueBlock), typeof(BrickBlock), 
            typeof(DottedBlock), typeof(LayeredBlock), typeof(LeftFacingDragonBlock), 
            typeof(PlainBlock), typeof(PyramidBlock), typeof(Rectangle1), typeof(Rectangle2), typeof(RightFacingDragonBlock)};
            foreach (var blockType in blockTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, blockType), new PlayerBlockCollisionHandler());
            }
            commandMap.Add(new Tuple<Type, Type>(typeof(MovableBlock), playerType), new MovableBlockPlayerCollisionHandler());
            
            foreach (Type enemyType in enemyTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, enemyType), new PlayerEnemyCollisionHandler());
            }
        }


        public void HandleCollision(ICollidable subject, ICollidable target, CollisionSide side)
        {
            Tuple<Type, Type> key = new Tuple<Type, Type>(subject.GetType(), target.GetType());
            if (commandMap.ContainsKey(key))
            {
                ICollisionHandler handler = commandMap[key];
                handler.HandleCollision(subject, target, side);
            }
        }
    }
}