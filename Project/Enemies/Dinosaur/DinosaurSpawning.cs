using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DinosaurSpawning : IEnemyState
    {
        private Dinosaur dinosaur;

        public DinosaurSpawning(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = EnemySpriteFactory.Instance.CreateEnemySpawnSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
        }

        public void Update(GameTime gameTime)
        {
        }

        public void UseWeapon()
        {
        }
    }
}
