using Microsoft.Xna.Framework;

namespace Project
{
    class TrapStill : IEnemyState
    {
        private Trap trap;

        public TrapStill(Trap trap)
        {
            this.trap = trap;
        }

        public void ChangeDirection(EnemyDirections direction)
        {
        }

        public void Update(GameTime gameTime)
        {
            //no animation or movement
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}
