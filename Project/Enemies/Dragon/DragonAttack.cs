using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;
using System;

namespace Project
{
    class DragonAttack : IEnemyState
    {
        private Dragon dragon;
        private Vector2 weaponPos;

        public DragonAttack(Dragon dragon)
        {
            this.dragon = dragon;
            this.dragon.EnemySprite = EnemySpriteFactory.Instance.CreateDragonAttackSprite();
            weaponPos = new Vector2(dragon.Position.X - 10, dragon.Position.Y);
            this.dragon.TopFireball = ItemSpriteFactory.Instance.CreateLeftUpFireballSprite(weaponPos);
            this.dragon.MiddleFireball = ItemSpriteFactory.Instance.CreateLeftFireballSprite(weaponPos);
            this.dragon.BottomFireball = ItemSpriteFactory.Instance.CreateLeftDownFireballSprite(weaponPos);
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    dragon.SetState(new DragonWalkRight(dragon));
                    break;
                case EnemyDirections.West:
                    dragon.SetState(new DragonWalkLeft(dragon));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (this.dragon.BottomFireball.isFinished())
            {
                dragon.SetState(new DragonWalkLeft(dragon));
                return;
            }

            dragon.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity) + dragon.Position.X, dragon.Position.Y);


            this.dragon.TopFireball.Update(gameTime);
            this.dragon.MiddleFireball.Update(gameTime);
            this.dragon.BottomFireball.Update(gameTime);
            
        }

        public void UseWeapon()
        {
        }
    }
}
