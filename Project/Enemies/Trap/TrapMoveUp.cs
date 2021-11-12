using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class TrapMoveUp : IEnemyState
    {
        private Trap trap;

        public TrapMoveUp(Trap trap)
        {
            this.trap = trap;
        }
        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.West:
                    trap.SetState(new TrapMoveLeft(trap));
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

            trap.Position = new Vector2(trap.Position.X, trap.Position.Y + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * trap.Velocity));
        }

        public void UseWeapon()
        {
        }
    }
}
