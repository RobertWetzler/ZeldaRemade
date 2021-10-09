using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class WallMaster : IEnemy
    {
        private int animationDelay; //animation speed
        private int timeToChangeDirection; //time to randomly change direction
        private int changeDirectionCounter;
        private int animationCounter;
        private IEnemyState currentState;
        private float xpos;
        private float ypos;
        private IEnemySprite sprite;
        private float velocity;
        private Random rand;
        public float XPos { get => xpos; set => xpos = value; }
        public float YPos { get => ypos; set => ypos = value; }
        public IEnemySprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }

        public WallMaster(float xPos, float yPos)
        {
            this.xpos = xPos;
            this.ypos = yPos;
            this.velocity = 50f;
            this.rand = new Random();
            animationDelay = 100;
            timeToChangeDirection = 1000;
            animationCounter = 0;
            changeDirectionCounter = 0;
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new WallMasterWalkEast(this);

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
            animationCounter += gameTime.ElapsedGameTime.Milliseconds;
            changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (animationCounter > animationDelay)
            {
                animationCounter -= animationDelay;
                sprite.Update();
            }
            if (changeDirectionCounter > timeToChangeDirection)
            {
                changeDirectionCounter -= timeToChangeDirection;
                int changeDirection = rand.Next(0, 8); //Random number b/w 0 and 7
                switch (changeDirection)
                {
                    case 1:
                        ChangeDirection(EnemyDirections.East);
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
            else if ((int)this.xpos > windowBounds.Right)
            {
                ChangeDirection(EnemyDirections.West);
            }

            currentState.Update(gameTime);


        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, xpos, ypos);
        }
    }

}