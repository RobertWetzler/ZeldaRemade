using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class GoriyaWalkWest : IEnemyState
    {
        private Goriya goriya;

        public GoriyaWalkWest(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = EnemySpriteFactory.Instance.CreateGoriyaWalkWestSprite();

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
            }
        }

        public void Update(GameTime gameTime)
        {
            goriya.Position = new Vector2((float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * goriya.Velocity) + goriya.Position.X,
                                     goriya.Position.Y);
        }

        public void UseWeapon()
        {
            goriya.SetState(new GoriyaUseItem(goriya));
        }
    }
}
