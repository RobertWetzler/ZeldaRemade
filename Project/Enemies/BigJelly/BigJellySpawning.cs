using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class BigJellySpawning : IEnemyState
    {
        private BigJelly bigJelly;

        public BigJellySpawning(BigJelly bigJelly)
        {
            this.bigJelly = bigJelly;
            this.bigJelly.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
