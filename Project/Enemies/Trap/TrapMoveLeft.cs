using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class TrapMoveLeft : IEnemyState
    {
        private Trap trap;

        public TrapMoveLeft(Trap trap)
        {
            this.trap = trap;
        }
        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    trap.SetState(new TrapMoveUp(trap));
                    break;
                case EnemyDirections.South:
                    trap.SetState(new TrapMoveDown(trap));
                    break;
                case EnemyDirections.East:
                    trap.SetState(new TrapMoveRight(trap));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            trap.Position = new Vector2(trap.Position.X + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * trap.Velocity), trap.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
