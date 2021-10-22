using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class SmallJellySpawning : IEnemyState
    {
        private SmallJelly smallJelly;

        public SmallJellySpawning(SmallJelly smallJelly)
        {
            this.smallJelly = smallJelly;
            this.smallJelly.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
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
