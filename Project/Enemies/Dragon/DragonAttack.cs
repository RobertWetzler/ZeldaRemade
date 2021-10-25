using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Projectiles;
using Project.Sprites.ItemSprites;
using Project.Utilities;
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
            dragon.TopFireball = new Fireball(Facing.Up, weaponPos, isFriendly: false);
            dragon.MiddleFireball = new Fireball(Facing.Left, weaponPos, isFriendly: false);
            dragon.BottomFireball = new Fireball(Facing.Down, weaponPos, isFriendly: false);
            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.TopFireball);
            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.MiddleFireball);
            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.BottomFireball);
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
            if (this.dragon.BottomFireball.IsFinished)
            {
                dragon.SetState(new DragonWalkLeft(dragon));
                return;
            }

            dragon.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity) + dragon.Position.X, dragon.Position.Y);
            
        }

        public void UseWeapon()
        {
        }
    }
}
