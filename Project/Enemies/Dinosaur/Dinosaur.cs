using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class Dinosaur : IEnemy
    {
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Dinosaur(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            movement = new EnemyMovement(this);
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new DinosaurWalkEast(this);

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
            movement.MoveWASDOnly(windowBounds, gameTime);
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

}