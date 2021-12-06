using Project.Collision.CollisionHandlers;
using Project.Collision.CollisionHandlers.Blocks;
using Project.Collision.CollisionHandlers.Doors;
using Project.Collision.CollisionHandlers.Enemies;
using System;
using System.Collections.Generic;

namespace Project.Collision
{
    class AllCollisionHandler : ICollisionHandler
    {
        private Dictionary<Tuple<CollisionType, CollisionType>, ICollisionHandler> commandMap;
        public AllCollisionHandler()
        {
            commandMap = new Dictionary<Tuple<CollisionType, CollisionType>, ICollisionHandler>();
            BuildDictionary();
        }

        private void BuildDictionary()
        {
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.Block), new PlayerBlockCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Enemy, CollisionType.Block), new EnemyBlockCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Darknut, CollisionType.Block), new EnemyBlockCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.BlueBlock), new PlayerBlockCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Enemy, CollisionType.BlueBlock), new EnemyBlockCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.Block), new ProjectileAnyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.MovableBlock), new ProjectileAnyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.NPC), new ProjectileAnyCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.StairBlock, CollisionType.Player), new StairBlockPlayerCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.MovableBlock, CollisionType.Player), new MovableBlockPlayerCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Enemy, CollisionType.MovableBlock), new EnemyMovableBlockCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Enemy, CollisionType.Bomb), new EnemyBombCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Bat, CollisionType.Bomb), new EnemyBombCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Darknut, CollisionType.Bomb), new EnemyBombCollisionHandler());


            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.Enemy), new PlayerEnemyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.Bat), new PlayerEnemyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.Darknut), new PlayerEnemyCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.NPC), new PlayerNPCCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Player, CollisionType.Projectile), new PlayerProjectileCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Item, CollisionType.Player), new ItemPlayerCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.Player), new ProjectilePlayerCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.Enemy), new ProjectileEnemyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.Bat), new ProjectileEnemyCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Projectile, CollisionType.Darknut), new ProjectileEnemyCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Enemy, CollisionType.Projectile), new EnemyProjectileCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Bat, CollisionType.Projectile), new EnemyProjectileCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Darknut, CollisionType.Projectile), new DarknutProjectileCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Door, CollisionType.Player), new DoorPlayerCollisionHandler());

            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Door, CollisionType.Player), new DoorPlayerCollisionHandler());
            commandMap.Add(new Tuple<CollisionType, CollisionType>(CollisionType.Door, CollisionType.Bomb), new DoorBombCollisionHandler());
        }


        public void HandleCollision(ICollidable collidee, ICollidable collider, CollisionSide side)
        {
            Tuple<CollisionType, CollisionType> key = new Tuple<CollisionType, CollisionType>(collidee.CollisionType, collider.CollisionType);
            if (commandMap.ContainsKey(key))
            {
                ICollisionHandler handler = commandMap[key];
                handler.HandleCollision(collidee, collider, side);
            }
        }
    }
}