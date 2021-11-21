using Microsoft.Xna.Framework;

namespace Project
{
    class TrapMoveRight : IEnemyState
    {
        private Trap trap;

        public TrapMoveRight(Trap trap)
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
                case EnemyDirections.West:
                    trap.SetState(new TrapMoveLeft(trap));
                    break;
                case EnemyDirections.South:
                    trap.SetState(new TrapMoveDown(trap));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            trap.Position = new Vector2(trap.Position.X + (float)(gameTime.ElapsedGameTime.TotalSeconds * trap.Velocity), trap.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
