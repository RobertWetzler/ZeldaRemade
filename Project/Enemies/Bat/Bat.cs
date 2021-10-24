using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Factory;
using System;
using System.Collections.Generic;

namespace Project
{
    class Bat : IEnemy
    {
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;

        public Vector2 Position { get => position; set => position = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public Bat(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.sprite = EnemySpriteFactory.Instance.CreateBatSprite();
            movement = new EnemyMovement(this);
            //TODO
            //Should start at a spawning state that has the spawning enemies animation
            currentState = new EnemyWalkEast(this);

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
            movement.MoveWASDAndDiagonal(windowBounds, gameTime);
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

}