using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;
using System.Collections.Generic;

namespace Project
{
    class Dinosaur : IEnemy
    {

        private const int timeToSpawn = 600;
        private const int timeToDespawn = 300;
        private int startTime;
        private int startTimeTwo;
        private IEnemyState currentState;
        private Vector2 position;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Health health;
        private double totalFlashTime = 750;
        private double remainingFlashTime;
        private Color colorTint;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }
        public Dinosaur(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            movement = new EnemyMovement(this);
            startTime = 0;
            currentState = new EnemySpawning(this);
            health = new Health(6);
            remainingFlashTime = 0;
            health = new Health(2);

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
            // No weapon
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
                    if (currentState is EnemySpawning)
                        startTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (startTime > timeToSpawn)
                    {
                        startTime += gameTime.ElapsedGameTime.Milliseconds;
                        if (startTime > timeToSpawn)
                        {
                            currentState = new DinosaurWalkEast(this);
                        }

                    }

                    movement.MoveWASDOnly(windowBounds, gameTime);
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

            if (currentState is EnemyDespawning)
            {
                startTimeTwo += gameTime.ElapsedGameTime.Milliseconds;
                if (startTimeTwo > timeToDespawn)
                {
                    ((IEnemy)this).Despawn();
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
