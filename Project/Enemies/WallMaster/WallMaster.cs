using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Utilities;
using System.Collections.Generic;

namespace Project
{
    class WallMaster : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private Vector2 pos;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Health health;
        private double totalFlashTime = 750;
        private double remainingFlashTime;
        private Color colorTint;
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => pos; set => pos = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }
        public WallMaster(Vector2 pos)
        {
            this.pos = pos;
            this.velocity = 50f;
            startTime = 0;
            timeToSpawn = 600;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(2);
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
                        currentState = new WallMasterWalkEast(this);
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

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            if (remainingFlashTime <= 0)
            {
                sprite.Draw(spriteBatch, pos, Color.White);
            }
            else
            {
                sprite.Draw(spriteBatch, pos, this.colorTint);
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