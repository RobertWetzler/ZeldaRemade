using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class EnemyWalkSE : IEnemyState
    {
        private IEnemy enemy;

        public EnemyWalkSE(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.North:
                    enemy.SetState(new EnemyWalkNorth(enemy));
                    break;
                case EnemyDirections.South:
                    enemy.SetState(new EnemyWalkSouth(enemy));
                    break;
                case EnemyDirections.West:
                    enemy.SetState(new EnemyWalkWest(enemy));
                    break;
                case EnemyDirections.Northeast:
                    enemy.SetState(new EnemyWalkNE(enemy));
                    break;
                case EnemyDirections.East:
                    enemy.SetState(new EnemyWalkEast(enemy));
                    break;
                case EnemyDirections.Southwest:
                    enemy.SetState(new EnemyWalkSW(enemy));
                    break;
                case EnemyDirections.Northwest:
                    enemy.SetState(new EnemyWalkNW(enemy));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            enemy.XPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * enemy.Velocity);
            enemy.YPos += (float)(gameTime.ElapsedGameTime.TotalSeconds * enemy.Velocity);
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}