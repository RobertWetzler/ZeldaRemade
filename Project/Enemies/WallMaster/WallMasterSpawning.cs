using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class WallMasterSpawning : IEnemyState
    {
        private WallMaster wallMaster;

        public WallMasterSpawning(WallMaster wallMaster)
        {
            this.wallMaster = wallMaster;
            this.wallMaster.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
