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
        private static List<EnemyDirections> DIRECTIONS = new List<EnemyDirections>()
        {
            EnemyDirections.East,
            EnemyDirections.West,
            EnemyDirections.North,
            EnemyDirections.South,
            EnemyDirections.Northeast,
            EnemyDirections.Southwest,
            EnemyDirections.Northwest,
            EnemyDirections.Southeast,
        };
        
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
                if (changeDirection < DIRECTIONS.Count)
                {
                    enemy.ChangeDirection(DIRECTIONS[changeDirection]);
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
                if (changeDirection < 4)
                {
                    enemy.ChangeDirection(DIRECTIONS[changeDirection]);
                }
            }
            CheckIfAtEdge(bounds);
        }

        public void MoveWASDOrAttack(Rectangle bounds, GameTime gameTime)
        {
            changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (changeDirectionCounter > timeToChangeDirection)
            {
                changeDirectionCounter -= timeToChangeDirection;
                int changeDirection = rand.Next(0, 9);
                if (changeDirection < 4)
                {
                    enemy.ChangeDirection(DIRECTIONS[changeDirection]);
                }else if(changeDirection >= 4 && changeDirection < 6)
                {
                    enemy.UseWeapon();
                }
            }
            CheckIfAtEdge(bounds);
        }

        public void CheckIfAtEdge(Rectangle bounds)
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
