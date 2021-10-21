using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
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
        private ISprite sprite;
        private float velocity;
        private Random rand;
        private IWeaponSprite boomerang;
        private Facing facingDirection;
        private Vector2 position;
        public Facing FacingDirection { get => facingDirection; set => facingDirection = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IWeaponSprite WeaponSprite { get => this.boomerang; set => this.boomerang = value; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Goriya(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.rand = new Random();
            this.facingDirection = Facing.Down;
            timeToChangeDirection = 1000;
            changeDirectionCounter = 0;
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new GoriyaWalkSouth(this);

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
            
            currentState.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
            if (currentState is GoriyaUseItem)
            {
                boomerang.Draw(spriteBatch);
            }
        }

       
    }

}