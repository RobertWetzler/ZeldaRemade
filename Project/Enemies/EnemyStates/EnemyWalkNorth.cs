using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class EnemyWalkNorth : IEnemyState
    {
        private IEnemy enemy;

        public EnemyWalkNorth(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    enemy.SetState(new EnemyWalkEast(enemy));
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
                case EnemyDirections.Southeast:
                    enemy.SetState(new EnemyWalkSE(enemy));
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
            enemy.YPos += (float)(-1 * gameTime.ElapsedGameTime.TotalSeconds * enemy.Velocity);
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}