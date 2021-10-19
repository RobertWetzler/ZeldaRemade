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
            ChangeDirection(EnemyDirections.East);
        }

        public void UseWeapon()
        {
            weaponPos = new Vector2(dragon.Position.X - 10, dragon.Position.Y);
            dragon.fireballs.Add(ItemSpriteFactory.Instance.CreateLeftUpFireballSprite(weaponPos));
            dragon.fireballs.Add(ItemSpriteFactory.Instance.CreateLeftFireballSprite(weaponPos));
            dragon.fireballs.Add(ItemSpriteFactory.Instance.CreateLeftDownFireballSprite(weaponPos));
        }
    }
}
