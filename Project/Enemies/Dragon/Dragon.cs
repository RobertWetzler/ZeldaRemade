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
    class Dragon : IEnemy
    {
        private int timeToAttack; 
        private int attackCounter;
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private float xpos;
        private float ypos;
        private IEnemySprite sprite;
        private float velocity;
        private IWeaponSprite topFireball;
        private IWeaponSprite middleFireball;
        private IWeaponSprite bottomFireball;
        public float XPos { get => xpos; set => xpos = value; }
        public float YPos { get => ypos; set => ypos = value; }
        public IEnemySprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public IWeaponSprite TopFireball { get => this.topFireball; set => this.topFireball = value; }
        public IWeaponSprite MiddleFireball { get => this.middleFireball; set => this.middleFireball = value; }
        public IWeaponSprite BottomFireball { get => this.bottomFireball; set => this.bottomFireball = value; }
        public Dragon(float xPos, float yPos)
        {
            this.xpos = xPos;
            this.ypos = yPos;
            this.velocity = 50f;

            timeToAttack = 3000;
            attackCounter = 0;
            startTime = 0;
            timeToSpawn = 600;
            currentState = new DragonSpawning(this);
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
            if (currentState is DragonSpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                    currentState = new DragonWalkLeft(this);
            }
            attackCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (attackCounter > timeToAttack)
            {
                attackCounter -= timeToAttack;
                UseWeapon();
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
            if (currentState is DragonAttack)
            {
                topFireball.Draw(spriteBatch);
                middleFireball.Draw(spriteBatch);
                bottomFireball.Draw(spriteBatch);
            }
        }


    }

}