using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project
{
    class GoriyaUseItem : IEnemyState
    {
        private Goriya goriya;
        private Vector2 weaponPos;

        public GoriyaUseItem(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = EnemySpriteFactory.Instance.CreateGoriyaUseItemSprite(goriya.FacingDirection);
            switch (goriya.FacingDirection)
            {
                case Facing.Up:
                case Facing.Down:
                    weaponPos = new Vector2(goriya.Position.X + 20, goriya.Position.Y);
                    break;
                default:
                    weaponPos = new Vector2(goriya.Position.X, goriya.Position.Y);
                    break;
            }
            this.goriya.WeaponSprite = ItemSpriteFactory.Instance.CreateBoomerangSprite(goriya.FacingDirection, weaponPos);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    goriya.SetState(new GoriyaWalkNorth(goriya));
                    break;
                case EnemyDirections.South:
                    goriya.SetState(new GoriyaWalkSouth(goriya));
                    break;
                case EnemyDirections.East:
                    goriya.SetState(new GoriyaWalkEast(goriya));
                    break;
                case EnemyDirections.West:
                    goriya.SetState(new GoriyaWalkWest(goriya));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            if (goriya.WeaponSprite.isFinished())
            {
                switch (goriya.FacingDirection)
                {
                    case Facing.Right:
                        goriya.SetState(new GoriyaWalkEast(goriya));
                        break;
                    case Facing.Down:
                        goriya.SetState(new GoriyaWalkSouth(goriya));
                        break;
                    case Facing.Up:
                        goriya.SetState(new GoriyaWalkNorth(goriya));
                        break;
                    case Facing.Left:
                        goriya.SetState(new GoriyaWalkWest(goriya));
                        break;
                }
                return;
            }
            goriya.WeaponSprite.Update(gameTime);
        }

        public void UseWeapon()
        {

        }
    }
}
