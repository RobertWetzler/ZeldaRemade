using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using Project.Projectiles;
using Project.Sprites.ItemSprites;
using Project.Utilities;
using System;
using System.Collections.Generic;

namespace Project
{
    class Dragon : IEnemy
    {
        private int timeToAttack; 
        private int attackCounter;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private IProjectile topFireball;
        private IProjectile middleFireball;
        private IProjectile bottomFireball;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IProjectile TopFireball { get => this.topFireball; set => this.topFireball = value; }
        public IProjectile MiddleFireball { get => this.middleFireball; set => this.middleFireball = value; }
        public IProjectile BottomFireball { get => this.bottomFireball; set => this.bottomFireball = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Vector2 Position { get => position; set => position = value; }

        public Dragon(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;

            timeToAttack = 3000;
            attackCounter = 0;
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new DragonWalkLeft(this);

        }

        public void ChangeDirection(EnemyDirections direction)
        {
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
            attackCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (attackCounter > timeToAttack)
            {
                attackCounter -= timeToAttack;
                UseWeapon();
            }
            
            currentState.Update(gameTime);
            

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
            if (currentState is DragonAttack)
            {
                topFireball.Draw(spriteBatch);
                middleFireball.Draw(spriteBatch);
                bottomFireball.Draw(spriteBatch);
            }
        }


    }

}