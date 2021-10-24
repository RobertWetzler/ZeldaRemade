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
    class Dragon : IEnemy
    {
        private int timeToAttack; 
        private int attackCounter;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        public List<IWeaponSprite> fireballs { get; private set; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }

        public Rectangle BoundingBox => sprite.DestRectangle;

        public Dragon(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.fireballs = new List<IWeaponSprite>();
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

            if ((int)position.X < windowBounds.Left)
            {
                ChangeDirection(EnemyDirections.East);
            }
            else if ((int)position.X > windowBounds.Right)
            {
                ChangeDirection(EnemyDirections.West);
            }

            attackCounter += gameTime.ElapsedGameTime.Milliseconds;
            if (attackCounter > timeToAttack)
            {
                attackCounter -= (2 * timeToAttack);
                currentState = new DragonAttack(this);
                UseWeapon();
            }

            sprite.Update(gameTime);
            currentState.Update(gameTime);
            foreach (IWeaponSprite fireball in fireballs)
            {
                fireball.Update(gameTime);
            }
            this.fireballs.RemoveAll(fireball => fireball.isFinished());
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
            foreach (IWeaponSprite fireball in fireballs)
            {
                fireball.Draw(spriteBatch);
            }
        }

    }

}