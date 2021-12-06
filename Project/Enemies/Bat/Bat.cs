using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;
using Project.Utilities;
using System.Collections.Generic;

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

        private double totalFlashTime = 750;
        private double remainingFlashTime;
        private Color colorTint;
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
            health = new Health(1);
            this.player = Game1.Instance.Player;
            remainingFlashTime = 0;
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            if (remainingFlashTime <= 0)
                currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            //No weapon
        }

        public void SetState(IEnemyState state)
        {
            if (remainingFlashTime <= 0)
                currentState = state;
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
            if (remainingFlashTime <= 0)
            {
                if (currentState is EnemySpawning)
                {
                    startTime += gameTime.ElapsedGameTime.Milliseconds;
                    if (startTime > timeToSpawn)
                    {
                        this.sprite = EnemySpriteFactory.Instance.CreateBatSprite();
                        currentState = new EnemyWalkEast(this);
                    }
                }
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