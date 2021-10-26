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
            //Use method to change to a moving state in some direction
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
