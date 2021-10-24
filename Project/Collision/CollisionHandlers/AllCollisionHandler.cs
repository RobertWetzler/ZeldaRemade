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
using Project.Sprites.PlayerSprites;

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

            commandMap.Add(new Tuple<Type, Type>(playerType, typeof(BlockSprite)), new PlayerBlockCollisionHandler());
            foreach (Type enemyType in enemyTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(enemyType, playerType), new PlayerEnemyCollisionHandler());
                commandMap.Add(new Tuple<Type, Type>(typeof(Sword), enemyType), new EnemyPlayerCollisionHandler());
            }
            
        }



        public void HandleCollision(ICollidable subject, ICollidable damage, CollisionSide side)
        {
            Tuple<Type, Type> key = new Tuple<Type, Type>(subject.GetType(), damage.GetType());
            if (commandMap.ContainsKey(key))
            {
                ICollisionHandler handler = commandMap[key];
                Console.WriteLine(handler);
                handler.HandleCollision(subject, damage, side);
            }
        }
    }
}
