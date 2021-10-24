﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Collision.CollisionHandlers
{
    class PlayerEnemyCollisionHandler: ICollisionHandler
    {
        public void HandleCollision(ICollidable enemy, ICollidable playerCollidable, CollisionSide side)
        {
            IPlayer player = playerCollidable as IPlayer;
            player.TakeDamage(1); //TODO: use a damage variable from enemy
        }
    }
}
