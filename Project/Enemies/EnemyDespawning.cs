using Microsoft.Xna.Framework;
using Project.Factory;
using Project.Sound;
using Project.Utilities;

namespace Project
{
    class EnemyDespawning : IEnemyState
    {
        private IEnemy enemy;
        public EnemyDespawning(IEnemy enemy)
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
