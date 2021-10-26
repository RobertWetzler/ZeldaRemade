using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DragonWalkLeft : IEnemyState
    {
        private Dragon dragon;

        public DragonWalkLeft(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = EnemySpriteFactory.Instance.CreateDragonWalkSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            dragon.SetState(new DragonWalkRight(dragon));
        }

        public void Update(GameTime gameTime)
        {
            this.dragon.Position = new Vector2((float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity) + dragon.Position.X,
                                                dragon.Position.Y);
        }

        public void UseWeapon()
        {
        }
    }
}
