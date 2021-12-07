using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DarknutWalkWest : IEnemyState
    {
        private Darknut darknut;

        public DarknutWalkWest(Darknut darknut)
        {
            this.darknut = darknut;
            this.darknut.EnemySprite = EnemySpriteFactory.Instance.CreateDarknutWalkWestSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    darknut.SetState(new DarknutWalkNorth(darknut));
                    break;
                case EnemyDirections.East:
                    darknut.SetState(new DarknutWalkEast(darknut));
                    break;
                case EnemyDirections.South:
                    darknut.SetState(new DarknutWalkSouth(darknut));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            darknut.Position = new Vector2((float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * darknut.Velocity) + darknut.Position.X,
                                     darknut.Position.Y);
        }

        public void UseWeapon()
        {

        }
    }
}