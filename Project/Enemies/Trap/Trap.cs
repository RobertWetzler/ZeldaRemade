using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class Trap : IEnemy, ICollidable
    {

        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;

        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Trap(Vector2 pos)
        {
            this.position = pos;
            this.velocity = 50f;
            this.sprite = EnemySpriteFactory.Instance.CreateTrapSprite();

            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new TrapStill(this);

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
            //Don't think they take damage
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

}