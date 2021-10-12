using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.ItemSprites;
using Project.Utilities;
using System;
using System.Collections.Generic;

namespace Project
{
    class Goriya : IEnemy
    {
        private int timeToChangeDirection; //time to randomly change direction
        private int changeDirectionCounter;
        private IEnemyState currentState;
        private float xpos;
        private float ypos;
        private IEnemySprite sprite;
        private float velocity;
        private Random rand;
        private IWeaponSprite boomerang;
        private Facing facingDirection;
        public Facing FacingDirection { get => facingDirection; set => facingDirection = value; }
        public float XPos { get => xpos; set => xpos = value; }
        public float YPos { get => ypos; set => ypos = value; }
        public IEnemySprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IWeaponSprite WeaponSprite { get => this.boomerang; set => this.boomerang = value; }

        public Goriya(float xPos, float yPos, Facing facingDirection)
        {
            this.xpos = xPos;
            this.ypos = yPos;
            this.velocity = 50f;
            this.rand = new Random();
            this.facingDirection = facingDirection;
            timeToChangeDirection = 1000;
            changeDirectionCounter = 0;
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            switch (this.facingDirection)
            {
                case Facing.Down:
                    currentState = new GoriyaWalkSouth(this);
                    break;
                case Facing.Left:
                    currentState = new GoriyaWalkWest(this);
                    break;
                case Facing.Right:
                    currentState = new GoriyaWalkEast(this);
                    break;
                case Facing.Up:
                    currentState = new GoriyaWalkNorth(this);
                    break;
            }

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            facingDirection = EnemyUtilities.GetFacingFromEnemyDirection(direction);
            currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            currentState.UseWeapon();
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
            if (!(currentState is GoriyaUseItem))
            {
                changeDirectionCounter += gameTime.ElapsedGameTime.Milliseconds;
                if (changeDirectionCounter > timeToChangeDirection)
                {
                    changeDirectionCounter -= timeToChangeDirection;
                    int changeDirection = rand.Next(0, 10); //Random number b/w 0 and 9
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
                        case 4:
                        case 5:
                            UseWeapon();
                            break;
                        default:
                            break;
                    }
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
            if (currentState is GoriyaUseItem)
            {
                boomerang.Draw(spriteBatch);
            }
        }

       
    }

}