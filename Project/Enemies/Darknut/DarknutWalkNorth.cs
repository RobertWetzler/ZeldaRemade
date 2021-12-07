using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DarknutWalkNorth : IEnemyState
    {
        private Darknut darknut;

        public DarknutWalkNorth(Darknut darknut)
        {
            this.darknut = darknut;
            this.darknut.EnemySprite = EnemySpriteFactory.Instance.CreateDarknutWalkNorthSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    darknut.SetState(new DarknutWalkEast(darknut));
                    break;
                case EnemyDirections.South:
                    darknut.SetState(new DarknutWalkSouth(darknut));
                    break;
                case EnemyDirections.West:
                    darknut.SetState(new DarknutWalkWest(darknut));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            darknut.Position = new Vector2(darknut.Position.X, darknut.Position.Y + (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * darknut.Velocity));
        }

        public void UseWeapon()
        {

        }
    }
}

