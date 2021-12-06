using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DinosaurWalkSouth : IEnemyState
    {

        private Dinosaur dinosaur;

        public DinosaurWalkSouth(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = EnemySpriteFactory.Instance.CreateDinosaurWalkDownSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    dinosaur.SetState(new DinosaurWalkNorth(dinosaur));
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