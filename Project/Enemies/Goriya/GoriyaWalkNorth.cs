using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class GoriyaWalkNorth : IEnemyState
    {
        private Goriya goriya;

        public GoriyaWalkNorth(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = EnemySpriteFactory.Instance.CreateGoriyaWalkNorthSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    goriya.SetState(new GoriyaWalkEast(goriya));
                    break;
                case EnemyDirections.South:
                    goriya.SetState(new GoriyaWalkSouth(goriya));
                    break;
                case EnemyDirections.West:
                    goriya.SetState(new GoriyaWalkWest(goriya));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            goriya.Position = new Vector2(goriya.Position.X, goriya.Position.Y + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * goriya.Velocity));
        }

        public void UseWeapon()
        {
            goriya.SetState(new GoriyaUseItem(goriya));
        }
    }
}
