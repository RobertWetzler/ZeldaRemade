using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DarknutWalkEast : IEnemyState
    {
        private Darknut darknut;

        public DarknutWalkEast(Darknut darknut)
        {
            this.darknut = darknut;
            this.darknut.EnemySprite = EnemySpriteFactory.Instance.CreateDarknutWalkEastSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    darknut.SetState(new DarknutWalkNorth(darknut));
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
            darknut.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * darknut.Velocity) + darknut.Position.X,
                                        darknut.Position.Y);
        }

        public void UseWeapon()
        {
           
        }
    }
}

