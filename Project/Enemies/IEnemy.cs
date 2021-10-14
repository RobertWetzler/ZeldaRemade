using Microsoft.Xna.Framework;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    /*
     * Represent an enemy. 
     * Enemy can move and take damage (extends IEntity),
     * has a sprite and position, and can use a weapon
     */
    public interface IEnemy : IEntity
    {
        public float XPos { get; set; }
        public float YPos { get; set; }
        public IEnemySprite EnemySprite { get; set; }
        public float Velocity { get; }
        void ChangeDirection(EnemyDirections direction);
        void SetState(IEnemyState state);
        void UseWeapon();

    }
}
