using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DragonWalkRight : IEnemyState
    {

        private Dragon dragon;

        public DragonWalkRight(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = EnemySpriteFactory.Instance.CreateDragonWalkSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            this.dragon.SetState(new DragonWalkLeft(dragon));
        }

        public void Update(GameTime gameTime)
        {
            this.dragon.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity) + dragon.Position.X,
                                                dragon.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
