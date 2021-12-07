using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Utilities;
using System.Collections.Generic;

namespace Project
{
    class SmallJelly : IEnemy
    {
 
        private int startTime;
        private const int timeToSpawn = 600;
        private const int timeToDespawn = 200;
        private int endTime;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Health health;
        private bool isFinished;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }
<<<<<<< HEAD
        public bool IsFinished => isFinished;
=======
        private double totalFlashTime = 750;
        private double remainingFlashTime;
        private Color colorTint;
>>>>>>> f858021b9586cc088b6438a1a7ef93f247bc03e2
        public SmallJelly(Vector2 pos)
        {
            this.position = pos;
            this.velocity = 50f;
         
          
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(1);
            remainingFlashTime = 0;
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            if (remainingFlashTime <= 0)
            {
                currentState.ChangeDirection(direction);
            }
        }

        public void UseWeapon()
        {
            //No weapon
        }

        public void SetState(IEnemyState state)
        {
            if (remainingFlashTime <= 0)
            {
                currentState = state;
            }

        }

        public void TakeDamage(int damage)
        {
            health.DecreaseHealth(damage);
            if (health.CurrentHealth > 0)
            {
                remainingFlashTime = totalFlashTime;
            }
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (remainingFlashTime <= 0)
            {
                if (currentState is EnemySpawning)
                {
                    startTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (startTime > timeToSpawn)
                    {
                        this.sprite = EnemySpriteFactory.Instance.CreateSmallJellySprite();
                        currentState = new EnemyWalkEast(this);
                    }
                }
<<<<<<< HEAD
            }
            if (currentState is EnemyDespawning)
            {
                endTime += gameTime.ElapsedGameTime.Milliseconds;
                if (endTime > timeToDespawn)
                {
                    isFinished = true;
                }
            }
=======
>>>>>>> f858021b9586cc088b6438a1a7ef93f247bc03e2

                movement.MoveWASDAndDiagonal(windowBounds, gameTime);

                currentState.Update(gameTime);
            }
            else
            {
                remainingFlashTime -= gameTime.ElapsedGameTime.TotalMilliseconds;
                if (remainingFlashTime > 0)
                {
                    UpdateColor();
                }
            }
               
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            if (remainingFlashTime <= 0)
            {
                sprite.Draw(spriteBatch, position, Color.White);
            }
            else
            {
                sprite.Draw(spriteBatch, position, this.colorTint);
            }
        }
        private void UpdateColor()
        {
            List<float> hues = new List<float>() { 140f, 180f, 260f, 340f };
            double t = totalFlashTime - remainingFlashTime;
            int i = (int)(t / totalFlashTime * hues.Count * 10) % hues.Count; // cycle through list
            colorTint = ColorUtils.HSVToRGB(hues[i], 1, 1);
        }
    }

}