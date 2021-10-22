using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class SkeletonSpawning : IEnemyState
    {
        private Skeleton skeleton;

        public SkeletonSpawning(Skeleton skeleton)
        {
            this.skeleton = skeleton;
            this.skeleton.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
