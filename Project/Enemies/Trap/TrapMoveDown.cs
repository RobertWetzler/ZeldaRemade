using Microsoft.Xna.Framework;

namespace Project
{
    class TrapMoveDown : IEnemyState
    {
        private Trap trap;

        public TrapMoveDown(Trap trap)
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
                case EnemyDirections.East:
                    trap.SetState(new TrapMoveRight(trap));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            trap.Position = new Vector2(trap.Position.X, trap.Position.Y + (float)(gameTime.ElapsedGameTime.TotalSeconds * trap.Velocity));
        }

        public void UseWeapon()
        {
        }
    }
}
