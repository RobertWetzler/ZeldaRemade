using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project
{
    class EnemyMovement
    {
        private int timeToChangeDirection; //time to randomly change direction
        private int changeDirectionCounter;
        private Random rand;
        private IEnemy enemy;
        
        public EnemyMovement(IEnemy enemy)
        {
            this.enemy = enemy;
            timeToChangeDirection = 1000;
            changeDirectionCounter = 0;
            rand = new Random();
        }

        public void MoveWASDAndDiagonal(Rectangle bounds, GameTime gameTime)
        {
            changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (changeDirectionCounter > timeToChangeDirection)
            {
                changeDirectionCounter -= timeToChangeDirection;
                int changeDirection = rand.Next(0, 16); 
                switch (changeDirection)
                {
                    case 0:
                        enemy.ChangeDirection(EnemyDirections.North);
                        break;
                    case 1:
                        enemy.ChangeDirection(EnemyDirections.East);
                        break;
                    case 2:
                        enemy.ChangeDirection(EnemyDirections.South);
                        break;
                    case 3:
                        enemy.ChangeDirection(EnemyDirections.West);
                        break;
                    case 4:
                        enemy.ChangeDirection(EnemyDirections.Northeast);
                        break;
                    case 5:
                        enemy.ChangeDirection(EnemyDirections.Southeast);
                        break;
                    case 6:
                        enemy.ChangeDirection(EnemyDirections.Southwest);
                        break;
                    case 7:
                        enemy.ChangeDirection(EnemyDirections.Northwest);
                        break;
                    default:
                        break;
                }
            }
            CheckIfAtEdge(bounds);
        }

        public void MoveWASDOnly(Rectangle bounds, GameTime gameTime)
        {
            changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (changeDirectionCounter > timeToChangeDirection)
            {
                changeDirectionCounter -= timeToChangeDirection;
                int changeDirection = rand.Next(0, 8); 
                switch (changeDirection)
                {
                    case 0:
                        enemy.ChangeDirection(EnemyDirections.North);
                        break;
                    case 1:
                        enemy.ChangeDirection(EnemyDirections.East);
                        break;
                    case 2:
                        enemy.ChangeDirection(EnemyDirections.South);
                        break;
                    case 3:
                        enemy.ChangeDirection(EnemyDirections.West);
                        break;
                    default:
                        break;
                }
            }
            CheckIfAtEdge(bounds);
        }

        private void CheckIfAtEdge(Rectangle bounds)
        {
            if ((int)enemy.Position.X <= bounds.Left)
            {
                enemy.ChangeDirection(EnemyDirections.East);
            }
            else if ((int)(enemy.Position.X + enemy.BoundingBox.Width) >= bounds.Right)
            {
                enemy.ChangeDirection(EnemyDirections.West);
            }
            else if ((int)enemy.Position.Y <= bounds.Top)
            {
                enemy.ChangeDirection(EnemyDirections.South);
            }
            else if ((int)(enemy.Position.Y + enemy.BoundingBox.Height) >= bounds.Bottom)
            {
                enemy.ChangeDirection(EnemyDirections.North);
            }
        }
    }
}
