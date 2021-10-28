using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class GoriyaWalkSouth : IEnemyState
    {
        private Goriya goriya;


        public GoriyaWalkSouth(Goriya goriya)
        {
            this.goriya = goriya;
            this.goriya.EnemySprite = EnemySpriteFactory.Instance.CreateGoriyaWalkSouthSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    goriya.SetState(new GoriyaWalkNorth(goriya));
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
            goriya.Position = new Vector2(goriya.Position.X, goriya.Position.Y + (float)(gameTime.ElapsedGameTime.TotalSeconds * goriya.Velocity));
        }

        public void UseWeapon()
        {
            goriya.SetState(new GoriyaUseItem(goriya));
        }
    }
}
