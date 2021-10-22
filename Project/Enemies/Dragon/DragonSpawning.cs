using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DragonSpawning : IEnemyState
    {
        private Dragon dragon;

        public DragonSpawning(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
