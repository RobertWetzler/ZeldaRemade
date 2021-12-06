using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DinosaurWalkNorth : IEnemyState
    {

        private Dinosaur dinosaur;

        public DinosaurWalkNorth(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = EnemySpriteFactory.Instance.CreateDinosaurWalkUpSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.South:
                    dinosaur.SetState(new DinosaurWalkSouth(dinosaur));
                    break;
                case EnemyDirections.East:
                    dinosaur.SetState(new DinosaurWalkEast(dinosaur));
                    break;
                case EnemyDirections.West:
                    dinosaur.SetState(new DinosaurWalkWest(dinosaur));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            dinosaur.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * dinosaur.Velocity) + dinosaur.Position.X,
                                            dinosaur.Position.Y);
        }

        public void UseWeapon()
        {

        }
    }
}