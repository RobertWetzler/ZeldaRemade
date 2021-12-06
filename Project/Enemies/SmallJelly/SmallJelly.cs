using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Factory;

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
        public bool IsFinished => isFinished;
        public SmallJelly(Vector2 pos)
        {
            this.position = pos;
            this.velocity = 50f;
         
          
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(1);
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
                    this.sprite = EnemySpriteFactory.Instance.CreateSmallJellySprite();
                    currentState = new EnemyWalkEast(this);
                }
            }
            if (currentState is EnemyDespawning)
            {
                endTime += gameTime.ElapsedGameTime.Milliseconds;
                if (endTime > timeToDespawn)
                {
                    isFinished = true;
                }
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