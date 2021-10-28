using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class EnemySpawning : IEnemyState
    {
        private IEnemy enemy;
        public EnemySpawning(IEnemy enemy)
        {
            this.enemy = enemy;
            this.enemy.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
