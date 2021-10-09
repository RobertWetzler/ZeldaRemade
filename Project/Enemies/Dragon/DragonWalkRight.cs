using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DragonWalkRight : IEnemyState
    {

        private Dragon dragon;

        public DragonWalkRight(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = NPCEnemySpriteFactory.Instance.CreateDragonWalkSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            this.dragon.SetState(new DragonWalkLeft(dragon));
        }

        public void Update(GameTime gameTime)
        {
            this.dragon.XPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity);
        }

        public void UseWeapon()
        {
            this.dragon.SetState(new DragonAttack(dragon));
        }
    }
}
