using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class Snake : IEnemy, ICollidable
    {
        private int timeToChangeDirection; //time to randomly change direction
        private int changeDirectionCounter;
        private IEnemyState currentState;
        private Vector2 pos;
        private ISprite sprite;
        private float velocity;
        private Random rand;

        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => pos; set => pos = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Snake(Vector2 pos)
        {
            this.pos = pos;
            this.velocity = 50f;
            this.rand = new Random();
            timeToChangeDirection = 1000;
            changeDirectionCounter = 0;

            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new SnakeWalkWest(this);

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

            currentState.Update(gameTime);


        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, pos);
        }
    }

}