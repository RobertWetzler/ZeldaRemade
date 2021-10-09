using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DragonWalkLeft : IEnemyState
    {
        private Dragon dragon;

        public DragonWalkLeft(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = NPCEnemySpriteFactory.Instance.CreateDragonWalkSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            dragon.SetState(new DragonWalkRight(dragon));
        }

        public void Update(GameTime gameTime)
        {
            this.dragon.XPos += (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity);
        }

        public void UseWeapon()
        {
            this.dragon.SetState(new DragonAttack(dragon));
        }
    }
}
