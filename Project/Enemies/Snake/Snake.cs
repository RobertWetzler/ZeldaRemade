using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class Snake : IEnemy
    {
        private int timeToChangeDirection; //time to randomly change direction
        private int changeDirectionCounter;
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private float xpos;
        private float ypos;
        private IEnemySprite sprite;
        private float velocity;
        private Random rand;
        private Facing facingDirection;
        public float XPos { get => xpos; set => xpos = value; }
        public float YPos { get => ypos; set => ypos = value; }
        public IEnemySprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }

        public Snake(float xPos, float yPos, Facing facing)
        {
            this.xpos = xPos;
            this.ypos = yPos;
            this.velocity = 50f;
            this.rand = new Random();
            timeToChangeDirection = 1000;
            changeDirectionCounter = 0;
            facingDirection = facing;
            startTime = 0;
            timeToSpawn = 600;
            currentState = new SnakeSpawning(this);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            //No weapon
        }

        public void SetState(IEnemyState state)
        {
            currentState = state;
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (currentState is SnakeSpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    switch (this.facingDirection)
                    {
                        case Facing.Down:
                            currentState = new SnakeWalkSouth(this);
                            break;
                        case Facing.Left:
                            currentState = new SnakeWalkWest(this);
                            break;
                        case Facing.Right:
                            currentState = new SnakeWalkEast(this);
                            break;
                        case Facing.Up:
                            currentState = new SnakeWalkNorth(this);
                            break;
                    }
                }
            }
            changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (changeDirectionCounter > timeToChangeDirection)
            {
                changeDirectionCounter -= timeToChangeDirection;
                int changeDirection = rand.Next(0, 16); //Random number b/w 0 and 15
                switch (changeDirection)
                {
                    case 0:
                        ChangeDirection(EnemyDirections.North);
                        break;
                    case 1:
                        ChangeDirection(EnemyDirections.East);
                        break;
                    case 2:
                        ChangeDirection(EnemyDirections.South);
                        break;
                    case 3:
                        ChangeDirection(EnemyDirections.West);
                        break;
                    default:
                        break;
                }
            }
            if ((int)this.xpos < windowBounds.Left)
            {
                ChangeDirection(EnemyDirections.East);
            }
            else if ((int)this.ypos < windowBounds.Top)
            {
                ChangeDirection(EnemyDirections.South);
            }
            else if ((int)this.xpos > windowBounds.Right)
            {
                ChangeDirection(EnemyDirections.West);
            }
            else if ((int)this.ypos > windowBounds.Bottom)
            {
                ChangeDirection(EnemyDirections.North);
            }
            currentState.Update(gameTime);


        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, xpos, ypos);
        }
    }

}