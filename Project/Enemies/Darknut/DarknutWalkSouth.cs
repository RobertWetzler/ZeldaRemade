using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DarknutWalkSouth : IEnemyState
    {
        private Darknut darknut;

        public DarknutWalkSouth(Darknut darknut)
        {
            this.darknut = darknut;
            this.darknut.EnemySprite = EnemySpriteFactory.Instance.CreateDarknutWalkSouthSprite();

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
                case EnemyDirections.West:
                    darknut.SetState(new DarknutWalkWest(darknut));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            darknut.Position = new Vector2(darknut.Position.X, darknut.Position.Y + (float)(gameTime.ElapsedGameTime.TotalSeconds * darknut.Velocity));
        }

        public void UseWeapon()
        {

        }
    }
}
