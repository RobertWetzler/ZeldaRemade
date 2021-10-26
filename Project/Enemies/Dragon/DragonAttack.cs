using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Factory;
using Project.Projectiles;
using Project.Utilities;

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
            this.dragon.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * this.dragon.Velocity) + dragon.Position.X,
                                               dragon.Position.Y);
            if (((DragonSprite)dragon.EnemySprite).oneCycleFinished)
            {
                ChangeDirection(EnemyDirections.East);
            }

        }

        public void UseWeapon()
        {
            weaponPos = new Vector2(dragon.Position.X - 10, dragon.Position.Y);

            dragon.fireballs.Add(new Fireball(Facing.Up, weaponPos, isFriendly: false));
            dragon.fireballs.Add(new Fireball(Facing.Left, weaponPos, isFriendly: false));
            dragon.fireballs.Add(new Fireball(Facing.Down, weaponPos, isFriendly: false));

            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.fireballs[0]);
            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.fireballs[1]);
            RoomManager.Instance.CurrentRoom.AddProjectile(dragon.fireballs[2]);
        }
    }
}
