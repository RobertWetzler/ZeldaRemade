using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class GoriyaSpawning : IEnemyState
    {
        private Goriya goriya;

        public GoriyaSpawning(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
