using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class TrapMove : IEnemyState
    {
        private Trap trap;
        private EnemyDirections direction;
        private Vector2 startPos;

        public TrapMove(Trap trap, EnemyDirections direction)
        {
            this.trap = trap;
            this.direction = direction;
            startPos = trap.Position;
        }
        public void ChangeDirection(EnemyDirections direction)
        {
        }

        public void Update(GameTime gameTime)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    break;
                case EnemyDirections.West:
                    break;
                case EnemyDirections.South:
                    break;
                case EnemyDirections.East:
                    break;
            }
        }

        public void UseWeapon()
        {
        }
    }
}
