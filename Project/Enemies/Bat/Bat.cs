using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using System;

namespace Project
{
    class Bat : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Health health;
        private IPlayer player;
        private static int X_DIFF = 100;
        private static int Y_DIFF = 100;

        public Vector2 Position { get => position; set => position = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Bat;
        public Health Health { get => health; }

        public Bat(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            startTime = 0;
            timeToSpawn = 600;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            this.player = Game1.Instance.Player;
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
            if (currentState is EnemySpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    this.sprite = EnemySpriteFactory.Instance.CreateBatSprite();
                    currentState = new EnemyWalkEast(this);
                }
            }
            if (Math.Abs((int)position.X - (int)player.Position.X) < X_DIFF
               && (Math.Abs((int)player.Position.Y - (int)position.Y) < Y_DIFF))
            {
                player.IsApproachBat = true;
            }
            if (player.IsApproachBat)
            {
                movement.timeToChangeDir = 250;
                this.velocity = 200f;
            }
            movement.MoveWASDAndDiagonal(windowBounds, gameTime);
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }

}