using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DinosaurWalkEast : IEnemyState
    {

        private Dinosaur dinosaur;

        public DinosaurWalkEast(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = NPCEnemySpriteFactory.Instance.CreateDinosaurLeftRightSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.West:
                    dinosaur.SetState(new DinosaurWalkWest(dinosaur));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            dinosaur.XPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * dinosaur.Velocity);
        }

        public void UseWeapon()
        {
            
        }
    }
}