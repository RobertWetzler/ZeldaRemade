using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class TrapSpawning : IEnemyState
    {
        private Trap trap;

        public TrapSpawning(Trap trap)
        {
            this.trap = trap;
            this.trap.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void UseWeapon()
        {
        }
    }
}
